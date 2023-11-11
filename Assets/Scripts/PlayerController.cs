using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerSpeed = 400;
    public Rigidbody2D playerRigidbody;

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.W)) {
            playerRigidbody.AddForce(transform.up * playerSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.A)) {
            playerRigidbody.AddForce(-transform.right * playerSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D)) {
            playerRigidbody.AddForce(transform.right * playerSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S)) {
            playerRigidbody.AddForce(-transform.up * playerSpeed * Time.deltaTime);
        }

		//rotation
		Vector3 mousePos = Input.mousePosition;

		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }
}
