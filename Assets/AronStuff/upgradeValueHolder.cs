using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum upgradeEnums
{
    speedUpgrade,
    launchSpeedUpgrade,
    healthUpgrade,
    other
}
public enum upgradeEffect
{
    add,
    remove,
    multiply,
    divide
}

public struct upgrade
{
    public upgradeEnums type;
    public string ingameName;
    public string ingameDescription;
    public upgradeEffect modifyerType;
    public float effectValue;
}

public class upgradeValueHolder : MonoBehaviour
{
    static public upgradeValueHolder instance;
    public List<upgrade> upgrades = new List<upgrade>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        upgrades.Add(
        new upgrade
        {
            type = upgradeEnums.speedUpgrade,
            ingameName = "speed upgrade mk1",
            ingameDescription = "increases your movement speed",
            modifyerType = upgradeEffect.multiply,
            effectValue = 1.1f
        });
        upgrades.Add(
        new upgrade
        {
            type = upgradeEnums.speedUpgrade,
            ingameName = "speed upgrade mk2",
            ingameDescription = "increases your movement speed",
            modifyerType = upgradeEffect.multiply,
            effectValue = 1.25f
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
