using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHandler : MonoBehaviour
{
    // Start is called before the first frame update

    RectTransform rect;

    public float health;
    void Start()
    {
         rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth(health);
    }

    public void updateHealth (float health)
    {

        ResizeWidth(health * 188);
    }

    public void damage(float damage)
    {
        health -= damage;
        updateHealth(health);
    }

    void ResizeWidth(float newWidth)
    {

        rect.sizeDelta = new Vector2(newWidth, rect.sizeDelta.y);
    }
}
