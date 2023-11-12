using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class phaseStuff : MonoBehaviour
{
    [SerializeField]
    private GameObject animHolder;
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        string x = textMeshProUGUI.text  + (waveDecider.Instance.currentWave + 1).ToString();
        Debug.Log("text = "+x);
        textMeshProUGUI.text = x;
    }
}
