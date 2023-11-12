using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautController : MonoBehaviour
{
    [SerializeField]
    public int maxAstronautCount = 5;

    [SerializeField]
    private RectTransform aliveAstronautsRect;
    [SerializeField]
    private RectTransform deadAstronautsRect;

    public int remainingAstronauts = 5;

    public void resetAstronauts() {
        remainingAstronauts = maxAstronautCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Alive astronauts
        remainingAstronauts = Math.Max(Math.Min(maxAstronautCount, remainingAstronauts), 0);
        aliveAstronautsRect.sizeDelta = new Vector2(100 * remainingAstronauts, 50);

        // Dead astronauts
        deadAstronautsRect.sizeDelta = new Vector2(100 * maxAstronautCount, 50);
    }
}
