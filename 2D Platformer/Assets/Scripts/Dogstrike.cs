using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dogstrike : PlayerAttack
{
    protected override void Awake(){
        base.Awake();
    }
    protected override void Update(){
        base.Update();
        
    }

    protected void ActivateDogstrike(){
        Debug.Log("This is dogstrike's version of this attack");
        base.ActivateHitbox();
        active = true;

    }
    
}
