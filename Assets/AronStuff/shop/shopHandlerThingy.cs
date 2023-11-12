using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopHandlerThingy : MonoBehaviour
{
    [SerializeField]
    private GameObject notUsedField;
    [SerializeField]
    private GameObject usedField;

    [SerializeField]
    private GameObject[] upgradeSlides = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < upgradeSlides.Length; i++)
        {
            shiftyThingy st = upgradeSlides[i].GetComponent<shiftyThingy>();
            if (st.isPromoted && !st.lastRememberedState)
            {
                upgradeSlides[i].transform.parent = usedField.transform;
                Debug.Log(st.myUpgrade.ToString());
                upgradeValueHolder.instance.addUpgrade(st.myUpgrade);
            }
            else if (!st.isPromoted && st.lastRememberedState) 
            {
                upgradeSlides[i].transform.parent = notUsedField.transform;
                Debug.Log(st.myUpgrade.ToString());
                upgradeValueHolder.instance.removeUpgrade(st.myUpgrade);
            }
        }
    }
}
