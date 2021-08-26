using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [Header("UI:")]
    [SerializeField] private Image ManaUI;
    [SerializeField] private Image HealthUI;
    [Header("Stats:")]
    [SerializeField] private int ManaMax;
    [SerializeField] private int ManaMultiplier;
    [SerializeField] private int HealthMax;
    [SerializeField] private int HealthMultiplier;
    [Header("External references:")]
    [SerializeField] private GameMenuScript gameMenuScript;
    private int Health;
    private int Mana;
    private void Start()
    {
        _CountByTheFormula(ref ManaMax,ManaMultiplier);
        _CountByTheFormula(ref HealthMax,HealthMultiplier);
        Mana = ManaMax;
        Health = HealthMax;
    }
    
    public void ReduceMana(int count)
    {
        if(Mana-count>=0)
        {
            Mana -= count;
        }
        else
        {
            Mana = 0;
        }
        DisplayHealthAndMana();
    }
    public void ReduceHealth(int count)
    {
        if(Health-count>0)
        {
            Health -= count;
        }
        else
        {
            Kill();
            return;
        }
        DisplayHealthAndMana();
    }
    private void DisplayHealthAndMana()
    {
        if(HealthUI!=null)
        {
            HealthUI.fillAmount = Health / (HealthMax / 100);
        }
        else
        {
            Debug.LogError("[CharacterStats] HealthUI is null");
        }
        if(ManaUI!=null)
        {
            ManaUI.fillAmount = Mana / (ManaMax / 100);
        }
        else
        {
            Debug.LogError("[CharacterStats] ManaUI is null");
        }
    }
    private void Kill()
    {
        Time.timeScale = 0;
        gameMenuScript.ShowRestart();
    }

    private void _CountByTheFormula(ref int variable,int multiplier)
    {
        variable = variable + (multiplier * PlayerPrefs.GetInt("PlayerLevel"));
    }
}
