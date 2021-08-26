using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "PowerGloves",         
    menuName = "Equipments/PowerGloves", order = 1)]
public class PowerGloves : EquipmentBase
{
    public int Force = 40;
   
    public override void Run(Kicker kicker)
    {
        Button.interactable = false;
        SimpleRoadController._speedMultiplier = 0;
        kicker.MiddleKick(()=>{

            Button.interactable = true;
            SimpleRoadController._speedMultiplier = 1;
        }, 40*(this.GetLevel()));
    }
}
