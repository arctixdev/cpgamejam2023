using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautController : MonoBehaviour
{
    [SerializeField]
    public int maxAstronautCount = 5;
    [HideInInspector]
    public int playerAstroAdditionModifyer = 0;
    [HideInInspector]
    private int calculatedPlayerAstro;

    private upgradeValueHolder ins;

    [SerializeField]
    private RectTransform aliveAstronautsRect;
    [SerializeField]
    private RectTransform deadAstronautsRect;

    public int remainingAstronauts = 5;

    public void Start()
    {
        Debug.Log("checking for upgradeholder script");
        ins = upgradeValueHolder.instance;
        if (ins == null) Debug.Log("v1 null");
        ins.upgradeChanged += upgradeChanged;
        recalcValues();
    }

    public void resetAstronauts() {
        remainingAstronauts = calculatedPlayerAstro;
    }

    // Update is called once per frame
    void Update()
    {
        // Alive astronauts
        remainingAstronauts = Math.Max(Math.Min(calculatedPlayerAstro, remainingAstronauts), 0);
        aliveAstronautsRect.sizeDelta = new Vector2(100 * remainingAstronauts, 50);

        // Dead astronauts
        deadAstronautsRect.sizeDelta = new Vector2(100 * calculatedPlayerAstro, 50);
    }

    void upgradeChanged(upgrade up)
    {
        if (up.type == upgradeEnums.speedUpgrade)
        {
            recalcValues();
        }
    }
    void recalcValues()
    {
        playerAstroAdditionModifyer = 0;
        for (int i = 0; i < ins.upgrades.Count; i++)
        {
            upgrade ue = ins.upgrades[i];
            if (ue.type == upgradeEnums.crewUpgrade)
            {
                if (ue.modifyerType == upgradeEffect.add)
                {
                    playerAstroAdditionModifyer += (int)ue.effectValue;
                }
            }
        }
        calculatedPlayerAstro = maxAstronautCount + playerAstroAdditionModifyer;
    }
}
