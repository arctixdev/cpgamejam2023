using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidCollision : MonoBehaviour
{
    public ParticleSystem asteroidParticle;
    public LayerMask asteroidLayer; // Specify the layer on which the particle effect should be triggered

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((asteroidLayer.value & (1 << collision.collider.gameObject.layer)) != 0)
        {
            asteroidParticle.Play();
            Invoke("DisableParticleEffect", 1f);
        }

    }

    void DisableParticleEffect()
    {
        // Stop the particle system and disable the GameObject
        asteroidParticle.Stop();
        gameObject.SetActive(false);
        print("stoppedpar");
    }
}
