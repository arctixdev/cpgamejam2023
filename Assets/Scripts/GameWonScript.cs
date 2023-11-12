using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonScript : MonoBehaviour
{
    void Update()
    {
        if (Time.timeSinceLevelLoad > 1) {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
