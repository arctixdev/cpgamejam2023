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

    [SerializeField]
    public float power = 0;

    [SerializeField]
    private int maxPower = 200;

    [SerializeField]
    private int powerMultiplier = 100;

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


    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            power = 0;
        } else if (Input.GetKey(KeyCode.Space)) {
            if (power < maxPower) {
                power += powerMultiplier * Time.deltaTime;
                updateZoom(power / maxPower);

            } else {
                power = maxPower;
            }
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            var spawnedProjectile = Instantiate(projectilePrefab, spawnLocation.position, spawnLocation.rotation);
            var rb = spawnedProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up.ConvertTo<Vector2>() * power + playerRb.velocity);
            timer = power / maxPower * zoomOutDur;
            power = 0;
 

        } else
        {
            updateZoom(outAnimCurve.Evaluate(timer / zoomOutDur));
        }




    }

    void updateZoom(float zoomProgress)
    {
        virtualCamera.m_Lens.OrthographicSize = 7.52f - zoomProgress;
    }
}
