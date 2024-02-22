using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class RisingAttack : PlayerAttack
{
    private bool falling = false;

    private bool charged = true;

    private bool bursted = false;


    [SerializeField] float rising_velocity = 15;

    [SerializeField] float gravity_reduction = 1.0f;

    private float stored_gravity;

    protected override void Awake(){
        base.Awake();
        active = false;
        stored_gravity = body.gravityScale; 
    }
    protected override void Update(){
        //Debug.Log(playerMovement.canAttack());
        //Debug.Log(playerMovement.isGrounded());
        

        if(playerMovement.isGrounded()){
            charged = true;
        }
        if(active){
            charged = false;
        }

        other_constraints = charged;

        
        base.Update();
        //hitboxes[1].gameObject.SetActive(true);
        detect_falling();

        if(falling && bursted){
            Deactivate();
        }

        
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
        body.gravityScale = stored_gravity;
        bursted = false;

    }


    private void freeze(){
        bursted = false;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void burst(){
        bursted = true;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.gravityScale *= gravity_reduction;
        body.velocity =  new UnityEngine.Vector2(0, rising_velocity);

    }
}
