using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    public string asteroid = "asteroidTag";
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
        if (collision.gameObject.CompareTag(asteroid))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
       
                if (collision.relativeVelocity.magnitude > minVelocityMagnitude)
                {

                    print("soundworks");
                    virAnim.SetTrigger("Explode");
                    virusAudio.PlayOneShot(hitVirus, 1f);

                    CircleCollider2D virCollider = GetComponent<CircleCollider2D>();
                    Destroy(virCollider);

                }
            
        }
    }

    public void Explode()
    {
        Destroy(gameObject);


    }
}
