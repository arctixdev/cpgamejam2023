using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float basePlayerSpeed = 400;
    [HideInInspector]
    public float playerSpeedAdditionModifyer = 0;
    public float playerSpeedMultiplyerModifyer = 1;
    private float calculatedPlayerSpeed;

    public Rigidbody2D playerRigidbody;
    private Animator ShipAnimator;

    private upgradeValueHolder ins;

    private void Start()
    {
        ins = upgradeValueHolder.instance;
        ShipAnimator = GetComponent<Animator>();
        ins.upgradeChanged += upgradeChanged;
        recalcValues();
    }
    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.W)) {
            playerRigidbody.AddForce(transform.up * calculatedPlayerSpeed * Time.deltaTime);
            ShipAnimator.SetTrigger("StartButton");
            ShipAnimator.SetBool("IsActive", true);
        } if (Input.GetKey(KeyCode.A)) {
            playerRigidbody.AddForce(-transform.right * calculatedPlayerSpeed * Time.deltaTime);
        } if (Input.GetKey(KeyCode.D)) {
            playerRigidbody.AddForce(transform.right * calculatedPlayerSpeed * Time.deltaTime);
        } if (Input.GetKey(KeyCode.S)) {
            playerRigidbody.AddForce(-transform.up * calculatedPlayerSpeed * Time.deltaTime);
        }
        
		//rotation
		Vector3 mousePos = Input.mousePosition;

		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }

    void upgradeChanged(upgrade up)
    {
        if(up.type == upgradeEnums.speedUpgrade)
        {
            recalcValues();
        }
    }
    void recalcValues()
    {
        playerSpeedAdditionModifyer = 0;
        playerSpeedMultiplyerModifyer = 1;
        for (int i = 0; i < ins.upgrades.Count; i++)
        {
            upgrade ue = ins.upgrades[i];
            if (ue.type == upgradeEnums.speedUpgrade)
            {
                if(ue.modifyerType == upgradeEffect.add)
                {
                    playerSpeedAdditionModifyer += ue.effectValue;
                }
                if (ue.modifyerType == upgradeEffect.multiply)
                {
                    playerSpeedMultiplyerModifyer += ue.effectValue;
                }
                if (ue.modifyerType == upgradeEffect.divide)
                {
                    playerSpeedAdditionModifyer /= ue.effectValue;
                }
                if (ue.modifyerType == upgradeEffect.remove)
                {
                    playerSpeedMultiplyerModifyer -= ue.effectValue;
                }
            }
        }
        calculatedPlayerSpeed = (basePlayerSpeed + playerSpeedAdditionModifyer) * playerSpeedMultiplyerModifyer;
    }
}
