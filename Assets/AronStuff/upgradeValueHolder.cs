using System;
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

[System.Serializable]
public struct upgrade
{
    /// <summary>
    /// the type of upgrade
    /// </summary>
    public upgradeEnums type;
    /// <summary>
    /// the name of the upgrade in th game
    /// </summary>
    public string ingameName;
    /// <summary>
    /// the description of the upgrade in the game
    /// </summary>
    public string ingameDescription;
    /// <summary>
    /// the type of modyfier to use like multiply or add
    /// </summary>
    public upgradeEffect modifyerType;
    /// <summary>
    /// how much to add remove or divide by. in case of multiply 0.1 = 110%
    /// </summary>
    public float effectValue;
    public int id;
}

public class upgradeValueHolder : MonoBehaviour
{
    static public upgradeValueHolder instance;
    public List<upgrade> upgrades = new List<upgrade>();

    public event Action<upgrade> upgradeChanged;

    void init()
    {
        instance = this;
    }
    private void Awake()
    {
        init();
    }
    void Start()
    {
        init();
        
        upgrades.Add(
        new upgrade
        {
            type = upgradeEnums.speedUpgrade,
            ingameName = "speed upgrade mk1",
            ingameDescription = "increases your movement speed",
            modifyerType = upgradeEffect.multiply,
            effectValue = 0.1f,
            id = 1
        });
        upgrades.Add(
        new upgrade
        {
            type = upgradeEnums.speedUpgrade,
            ingameName = "speed upgrade mk2",
            ingameDescription = "increases your movement speed",
            modifyerType = upgradeEffect.multiply,
            effectValue = 0.25f,
            id = 2
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int addUpgrade(upgrade upgrade)
    {
        try
        {
            upgradeChanged?.Invoke(upgrade);
            for (int i = 0; i < upgrades.Count; i++)
            {
                if (upgrades[i].id == upgrade.id) return upgrades[i].id;
            }
            upgrades.Add(upgrade);
        }
        catch
        {
            return -1;
        }
        return upgrade.id;
    }
    public upgrade removeUpgrade(upgrade upgrade)
    {
        upgrades.Remove(upgrade);
        return upgrade;
    }
}
