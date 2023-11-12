using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class shopHandlerThingy : MonoBehaviour
{
    [SerializeField]
    private GameObject notUsedField;
    [SerializeField]
    private GameObject usedField;
    [SerializeField]
    private GameObject[] usedSlots;
    [SerializeField]
    private GameObject[] notUsedSlots;

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
            GameObject us = upgradeSlides[i];
            shiftyThingy st = us.GetComponent<shiftyThingy>();
            if (st.isPromoted && !st.lastRememberedState)
            {
                for(int j = 0; j < usedSlots.Length; j++)
                {
                    if (!usedSlots[j].GetComponent<simpleBoolContainer>().occupied)
                    {
                        us.transform.parent.GetComponent<simpleBoolContainer>().occupied = false;
                        us.transform.SetParent(usedSlots[j].transform);
                        us.transform.parent.GetComponent<simpleBoolContainer>().occupied = true;
                        break;
                    }
                }
                us.transform.localPosition = Vector3.zero;
                Debug.Log("promoting upgrade");
                upgradeValueHolder.instance.addUpgrade(st.myUpgrade);
                st.lastRememberedState = true;
            }
            else if (!st.isPromoted && st.lastRememberedState) 
            {
                for (int j = 0; j < usedSlots.Length; j++)
                {
                    if (!notUsedSlots[j].GetComponent<simpleBoolContainer>().occupied)
                    {
                        us.transform.parent.GetComponent<simpleBoolContainer>().occupied = false;
                        us.transform.SetParent(notUsedSlots[j].transform);
                        us.transform.parent.GetComponent<simpleBoolContainer>().occupied = true;
                        break;
                    }

                }
                us.transform.localPosition = Vector3.zero;
                Debug.Log("demoting upgrade");
                upgradeValueHolder.instance.removeUpgrade(st.myUpgrade);
                st.lastRememberedState = false;
            }
        }
    }
}
