using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveDecider : MonoBehaviour
{
    public static waveDecider Instance;
    public int currentWave = -1;
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
        return currentWave;
    }
}