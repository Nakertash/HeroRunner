using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{

    [Header("Equipments sprites")]
    [SerializeField] private SpriteRenderer Head;
    [SerializeField] private SpriteRenderer Body;
    [SerializeField] private SpriteRenderer Hands;
    [SerializeField] private SpriteRenderer Legs;
    [Header("Prefabs/Other objects")]
    [SerializeField] public Kicker Kicker;
    [SerializeField] private MyAnimationController animController;
    [SerializeField] private EquipmentBase[] Slots = new EquipmentBase[4];
    void Start()
    {
        Kicker.Init(Slots, animController);
        animController.Play("Run");
        //Time.timeScale = 0.25f;
    }
    
}



[Serializable]
public class MyAnimationController
{
    [SerializeField] private Animator animation;

    private string _currentClipName;

    public string CurrentClipName { 
        get 
        {
            return this._currentClipName; 
        }
        private set
        {
            this._currentClipName = value; 
        } 
    }
    public void Play(string clipName)
    {
        CurrentClipName = clipName;
        animation.Play(clipName);
    }
}

public static class Extensions
{
    public static float RoundTo(this float val,int count)
    {
        float result = val;
        string FloatData = val.ToString();

        if(count<FloatData.Length- FloatData.IndexOf(",") + 1)
        {
            FloatData = FloatData.Substring(0, FloatData.IndexOf(",") + 1 + count);
            result = float.Parse(FloatData);
        }
        return result;
    }
}
