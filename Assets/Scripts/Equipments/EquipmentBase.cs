using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public abstract class EquipmentBase:ScriptableObject
{
    [SerializeField] protected string Name;

    [SerializeField] protected Sprite[] Icon;
    
    [SerializeField] protected Sprite[] RealSprite;

    [SerializeField] protected int Energy—onsumption;
    
    [SerializeField] protected int MaxLevel;

    [SerializeField] protected int Cost;

    [SerializeField] public Button Button;

    protected int GetLevel()
    {
        int result = 0;
        result = PlayerPrefs.GetInt(Name+"_level",0);
        return result;
    }

    public abstract void Run(Kicker kicker);
}
