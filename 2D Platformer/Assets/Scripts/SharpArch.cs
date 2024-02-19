using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpArch : PlayerAttack
{
    protected override void Awake(){
        base.Awake();
    }
    protected override void Update(){
        base.Update();
        
    }
    // Start is called before the first frame update
    protected void ActivateSharpArch(){
        Debug.Log("This is Sharp Arch's version of this attack.");
        foreach(Hitbox hitbox in hitboxes){
            hitbox.gameObject.SetActive(true);
        }
        active = true;
    }
}
