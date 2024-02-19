using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class RisingAttack : PlayerAttack
{
    private bool falling = false;

    private bool charged = true;

    [SerializeField] float rising_velocity = 15;

    protected override void Awake(){
        base.Awake();
        active = false;
    }
    protected override void Update(){
        //Debug.Log(playerMovement.canAttack());
        

        if(playerMovement.isGrounded()){
            charged = true;
        }
        if(active){
            charged = false;
        }

        other_constraints = charged;

        
        base.Update();
        //hitboxes[1].gameObject.SetActive(true);
        if(falling && active){
            Deactivate();
        }

        detect_falling();
        
    }

    private void detect_falling(){
        if(!playerMovement.isGrounded() && body.velocity[1] < 0){
            falling = true;
        }else{
            falling = false;
        }
        anim.SetBool("falling", falling);
    }

    private void Deactivate(){
        //Debug.Log("Skyslash deactivated the attack!");
        base.DeactivateHitbox();
        playerMovement.setAttackStateFalse();

    }

    protected void ActivateRising(){
        //Debug.Log("This is Sky Slash's version of this attack.");
        foreach(Hitbox hitbox in hitboxes){
            hitbox.gameObject.SetActive(true);
        }
    }

    private void freeze(){
        body.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void burst(){
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.velocity =  new UnityEngine.Vector2(0, rising_velocity);

    }
}
