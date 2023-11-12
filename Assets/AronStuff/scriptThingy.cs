using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptThingy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefs;
    // Start is called before the first frame update
    private void Awake()
    {
        if(upgradeValueHolder.instance == null)
        {
            Debug.LogWarning("could not find a important gameobject adding it");
            Instantiate(prefs[0]);
        }
    }
}