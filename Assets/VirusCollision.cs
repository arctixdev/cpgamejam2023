using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    // Specify the layer that should trigger destruction
    public string asteroid = "asteroidTag";
    // Specify the minimum velocity threshold for destruction
    public float minVelocityMagnitude = 0.1f;

    public AudioSource virusAudio;
    public AudioClip hitVirus;
    public Animator virAnim;
    private void Start()
    {
        virAnim = GetComponent<Animator>();
        virusAudio = GetComponent<AudioSource>();
    }
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

                    print("soundworks");
                    virAnim.SetTrigger("Explode");
                    virusAudio.PlayOneShot(hitVirus, 1f);

                    CircleCollider2D virCollider = GetComponent<CircleCollider2D>();
                    Destroy(virCollider);
                    // If it has the target tag and is moving, destroy the GameObject

                }
            }
        }
    }

    public void Explode()
    {
        Destroy(gameObject);


    }
}
