using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            power = 0;
        } else if (Input.GetKey(KeyCode.Space)) {
            if (power < maxPower) {
                power += powerMultiplier * Time.deltaTime;
            } else {
                power = maxPower;
            }
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            var spawnedProjectile = Instantiate(projectilePrefab, spawnLocation.position, spawnLocation.rotation);
            var rb = spawnedProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up.ConvertTo<Vector2>() * power + playerRb.velocity);
            power = 0;
        }
    }
}
