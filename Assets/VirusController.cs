using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{

    Transform playerTransofmr;
    public float speed = 0.5f;
    public float maxOffset = 1.0f;

    private void Start()
    {
        playerTransofmr = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Update()
    {
        if (playerTransofmr != null)
        {
            float randomXOffset = Random.Range(-maxOffset, maxOffset);
            float randomYOffset = Random.Range(-maxOffset, maxOffset);

            Vector2 targetPositionWithOffset = new Vector2(playerTransofmr.position.x + randomXOffset, playerTransofmr.position.y + randomYOffset);
            Vector2 newPosition = Vector2.Lerp(transform.position, targetPositionWithOffset, Time.deltaTime * speed / transform.localScale.x);

            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
