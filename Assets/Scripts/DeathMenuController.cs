using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public AudioSource audioSource;
    public void backToMenu() {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }
}
