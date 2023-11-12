using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    // Specify the layer that should trigger destruction
    public string asteroid = "asteroidTag";

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the colliding object is on the specified layer
        if (collision.gameObject.CompareTag(asteroid)) { 

            // If it is on the target layer, destroy the GameObject
            Destroy(gameObject);
        }
    }
}
