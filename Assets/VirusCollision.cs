using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    // Specify the layer that should trigger destruction
    public LayerMask asteroidLayer;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is on the specified layer
        if ((asteroidLayer == collision.gameObject.layer)) { 
            // If it is on the target layer, destroy the GameObject
            Destroy(gameObject);
        }
    }
}
