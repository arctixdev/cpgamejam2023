using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class moneh : MonoBehaviour
{
    [SerializeField]
    private GameObject monehCount;
    [SerializeField]
    private GameObject pack;
    public int miMoneh;

    public static moneh instance;
    private void Start()
    {
        instance = this;
        //fetchMoneh();
    }
    public void fetchMoneh()
    {
        if (waveDecider.Instance == null) { Instantiate(pack); Debug.Log("spawnin"); }
        //miMoneh += waveDecider.Instance.nextReward;
        waveDecider.Instance.nextReward = 0;
        monehCount.GetComponent<TextMeshProUGUI>().text = miMoneh.ToString();
    }
}
