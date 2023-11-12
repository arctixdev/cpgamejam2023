using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip theme;
    public AudioClip theme_loopable;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = theme;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            audioSource.clip = theme_loopable;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
