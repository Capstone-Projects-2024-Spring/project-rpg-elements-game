using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*
    Used for basic attacks that do nothing special and follow basic attack logic.
    In fact, we might not need this script at all and could just un-abstract PlayerAttack.
    Buuuut I've already integrated a few of attacks with this so I guess it stays O_O
*/
public class NormalAttack : PlayerAttack
{

    protected override void Awake(){
        base.Awake();
    }
    protected override void Update(){
        base.Update();
        
    }

}
