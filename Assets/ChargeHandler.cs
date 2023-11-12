using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeHandler : MonoBehaviour
{


    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    
    void ResizeWidth(float newWidth)
    {

        rect.sizeDelta = new Vector2(newWidth, rect.sizeDelta.y);
    }

}
