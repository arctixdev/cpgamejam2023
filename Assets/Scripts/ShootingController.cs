using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using UnityEditor;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    public AudioSource audioShooting;

    public AudioClip shootingClip;

    [SerializeField]
    public float power = 0;

    [SerializeField]
    private int maxBasePower = 200;

    [SerializeField]
    private int chargeupSpeed = 100;

    [SerializeField]
    private Transform spawnLocation;

    private Rigidbody2D playerRb;

    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    float timer = 0;

    [SerializeField]
    private float zoomOutDur;

    [SerializeField]
    private AnimationCurve outAnimCurve;

    [SerializeField]
    private float zoomPower;

    private float startFOV;

    [SerializeField]
    private AstronautController astronautController;

    private upgradeValueHolder ins;

    [SerializeField]
    private bool debugPower;
    private float calculatedMaxBasePower;

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        audioShooting = GetComponent<AudioSource>();
        startFOV = virtualCamera.m_Lens.FieldOfView;

        Debug.Log("checking for upgradeholder script");
        ins = upgradeValueHolder.instance;
        if (ins == null) Debug.Log("v1 null");
        ins.upgradeChanged += upgradeChanged;
        recalcValues();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else if (timer < 0) { 
            timer = 0;
        }

        if (astronautController.remainingAstronauts > 0) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                power = 0;
            } else if (Input.GetKey(KeyCode.Space)) {
                if (power < calculatedMaxBasePower) {
                    power += chargeupSpeed * Time.deltaTime;
                    updateZoom(power / calculatedMaxBasePower);

                } else {
                    power = calculatedMaxBasePower;
                }
            } else if (Input.GetKeyUp(KeyCode.Space)) {
                var spawnedProjectile = Instantiate(projectilePrefab, spawnLocation.position, spawnLocation.rotation);
                var rb = spawnedProjectile.GetComponent<Rigidbody2D>();
                audioShooting.PlayOneShot(shootingClip, 0.7f);
                rb.velocity = playerRb.velocity;
                rb.AddForce(transform.up.ConvertTo<Vector2>() * power);
                timer = power / calculatedMaxBasePower * zoomOutDur;
                power = 0;
                astronautController.remainingAstronauts -= 1;
            } else if(timer >= 0) 
            {
                updateZoom(outAnimCurve.Evaluate(timer / zoomOutDur));
            }
        } else if(timer >= 0)
        {
            updateZoom(outAnimCurve.Evaluate(timer / zoomOutDur));
        }
    }

    void upgradeChanged(upgrade up)
    {
        if (up.type == upgradeEnums.speedUpgrade)
        {
            recalcValues();
        }
    }
    [HideInInspector]
    public float shootMaxAdditionModifyer = 0;
    public float shootMaxMultiplyerModifyer = 1;
    void recalcValues()
    {
        shootMaxAdditionModifyer = 0;
        shootMaxMultiplyerModifyer = 1;
        for (int i = 0; i < ins.upgrades.Count; i++)
        {
            upgrade ue = ins.upgrades[i];
            if (ue.type == upgradeEnums.launchSpeedUpgrade)
            {
                if (ue.modifyerType == upgradeEffect.add)
                {
                    shootMaxAdditionModifyer += ue.effectValue;
                }
                if (ue.modifyerType == upgradeEffect.multiply)
                {
                    shootMaxMultiplyerModifyer += ue.effectValue;
                }
                if (ue.modifyerType == upgradeEffect.divide)
                {
                    shootMaxAdditionModifyer /= ue.effectValue;
                }
                if (ue.modifyerType == upgradeEffect.remove)
                {
                    shootMaxMultiplyerModifyer -= ue.effectValue;
                }
            }
        }
        calculatedMaxBasePower = (maxBasePower + shootMaxAdditionModifyer) * shootMaxMultiplyerModifyer;
    }

    void updateZoom(float zoomProgress)
    {
        virtualCamera.m_Lens.FieldOfView = startFOV - zoomProgress * zoomPower;
    }
}
