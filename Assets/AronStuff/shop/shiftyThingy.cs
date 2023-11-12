using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shiftyThingy : MonoBehaviour
{
    [SerializeField]
    private GameObject demote;
    [SerializeField]
    private GameObject promote;
    [SerializeField]
    private GameObject textField;

    [HideInInspector]
    public bool isPromoted;
    [HideInInspector]
    public bool lastRememberedState;

    public upgrade myUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        textField.GetComponent<TextMeshProUGUI>().text = myUpgrade.ingameName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void notUsed()
    {
        promote.SetActive(true);
        demote.SetActive(false);
        isPromoted = false;
    }
    public void used() 
    {
        demote.SetActive(false);
        demote.SetActive(true);
        isPromoted = true;
    }
}
