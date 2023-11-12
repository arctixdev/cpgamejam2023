using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{

    public Transform player;
    public float speed = 0.5f; // Adjust the speed of the movement
    public float maxOffset = 1.0f; // Maximum random offset

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float randomXOffset = Random.Range(-maxOffset, maxOffset);
            float randomYOffset = Random.Range(-maxOffset, maxOffset);

            // Calculate the new position using Lerp with random offsets
            Vector2 targetPositionWithOffset = new Vector2(player.position.x + randomXOffset, player.position.y + randomYOffset);
            Vector2 newPosition = Vector2.Lerp(transform.position, targetPositionWithOffset, Time.deltaTime * speed);

            // Update the object's position
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
