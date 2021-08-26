using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kicker : MonoBehaviour
{
    [Header("Attack animation keys:")]
    [SerializeField] private string MiddleKickAnim = "MiddleKickAnim";
    [SerializeField] private string HighKickAnim = "HighKickAnim";
    [SerializeField] private string MiddleInstAnim = "MiddleInstAnim";
    [SerializeField] private string HighInstAnim = "HighInstAnim";
    [SerializeField] private string LowInstAnim = "LowInstAnim";
    [Header("Slots:")]
    [HideInInspector] private EquipmentBase[] Slots = new EquipmentBase[4];
    [Header("Hit objects:")]
    [SerializeField] private Transform High;
    [SerializeField] private Transform Middle;


    [HideInInspector] private MyAnimationController AnimController;


    private BeatableObject target;
    private float force;
    private Action Callback;
    private string MainAnim;
    public void Init(EquipmentBase[] slots, MyAnimationController animController)
    {
        Slots = slots;
        AnimController = animController;
    }

    public void DefaultAbilityClick()
    {
        Slots[0].Run(this);
    }

    public void FirstAbilityClick()
    {
        Slots[1].Run(this);
    }

    public void SecondAbilityClick()
    {
        Slots[2].Run(this);
    }

    public void ThirdAbilityClick()
    {
        Slots[3].Run(this);
    }

    public void HighKick(Action callback, float force = 20)
    {

    }
    public void MiddleKick(Action callback, float force = 20)
    {
        Fight2D.Action(Middle.position,0.2f,0,force,(obj,damage)=> {
            if(obj!=null)
            {
                this.target = obj.GetComponent<BeatableObject>();
                MainAnim = AnimController.CurrentClipName;
                AnimController.Play(MiddleKickAnim);
                this.force = damage;
            }
            else
            {
                Debug.LogError("Enemy not found");
                callback();
            }
            
        
        });
    }

    public void Kick()
    {
        target.TakeDamage(force);
    }

    public void CallCallBack()
    {
        Callback?.Invoke();
        AnimController.Play(MainAnim);
    }
    public void InstantiateHigh(GameObject prefab)
    {

    }
    public void InstantiateMiddle(GameObject prefab)
    {

    }
    public void InstantiateLow(GameObject prefab)
    {

    }
}