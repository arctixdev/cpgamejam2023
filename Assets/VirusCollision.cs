using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    // Specify the layer that should trigger destruction
    public string asteroid = "asteroidTag";
    // Specify the minimum velocity threshold for destruction
    public float minVelocityMagnitude = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(asteroid))
        {
            // Check if the colliding object has a Rigidbody
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Check if the object is moving based on its velocity magnitude
                if (collision.relativeVelocity.magnitude > minVelocityMagnitude)
                {
                    // If it has the target tag and is moving, destroy the GameObject
                    Destroy(gameObject);
                }
            }
        }
    }
}
