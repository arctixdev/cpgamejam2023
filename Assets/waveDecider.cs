using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waveDecider : MonoBehaviour
{
    public static waveDecider Instance;
    public int currentWave = -1;
    public int nextReward;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int startNewWave()
    {
        currentWave++;
        if (currentWave == 3) {
            SceneManager.LoadScene("GameWonScene");
        }
        return currentWave;
    }
    public void giveReward(int reward)
    {
        nextReward += reward;
    }
}
