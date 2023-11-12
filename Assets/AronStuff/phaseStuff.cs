using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class phaseStuff : MonoBehaviour
{
    [SerializeField]
    private GameObject animHolder;
    private void Awake()
    {
        animHolder.GetComponent<TextMeshProUGUI>().text = animHolder.GetComponent<TextMeshProUGUI>().text + (waveDecider.Instance.currentWave+1).ToString();
    }
}
