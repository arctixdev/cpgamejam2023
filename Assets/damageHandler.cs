using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class damageHandler : MonoBehaviour
{

    public string asteroid = "asteroidTag";
    public string enemy = "enemyTag";

    [SerializeField]
    private healthHandler healthHandler;

    [SerializeField]
    private float astroidAttackPower;

    [SerializeField]
    private float enemyAttackPower;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage(float damage)
    {
        healthHandler.damage(damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(asteroid))
        {
            takeDamage(collision.relativeVelocity.magnitude * astroidAttackPower);
        }

        if (collision.gameObject.CompareTag(enemy))
        {
            takeDamage(enemyAttackPower);
        }
    }
}
