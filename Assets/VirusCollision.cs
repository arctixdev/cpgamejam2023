using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    [SerializeField]
    private string asteroidTagName = "asteroidTag";

    [SerializeField]
    private float minSpeedForKill = 0.1f;

    [SerializeField]
    private AudioSource virusAudioSource;
    
    [SerializeField]
    private AudioClip hitVirusSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(asteroidTagName))
        {
            Rigidbody2D colliderRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (colliderRb && collision.relativeVelocity.magnitude > minSpeedForKill)
            {
                virusAudioSource.PlayOneShot(hitVirusSound, 1f);
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
