using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private Movement playerMovement;

    public int power = 10;
    public Hitbox[] hitboxes;
    private void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        setPower();

    }

    private void setPower(){
        foreach(Hitbox hitbox in hitboxes){
            hitbox.setDamage(power);
        }
    }

    private void Update(){
        if(Input.GetKey(KeyCode.LeftShift) && playerMovement.canAttack()){
            Attack();
        }

    }

    private void Attack(){
        anim.SetTrigger("attack");
    }

    void ActivateHitbox(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

    void DeactivateHitbox(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

}
