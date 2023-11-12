using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundWonScript : MonoBehaviour
{
    void Update()
    {
        if (Time.timeSinceLevelLoad > 1) {
            SceneManager.LoadScene("UpgradeScene");
        }
    }
}
