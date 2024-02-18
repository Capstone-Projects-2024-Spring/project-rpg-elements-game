using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : Attack
{
    protected PlayerMovement playerMovement;

    protected override void Awake(){
        base.Awake();
        playerMovement = GetComponent<PlayerMovement>();
    }

    protected override void Update(){
        if (Input.GetKey(KeyCode.LeftShift) && playerMovement.canAttack())
        {
            attack();
        }
        base.Update();

    }

    protected override void setKnockbackDirection()
    {
        if (playerMovement.getDirection() == Direction.left)
        {
            knockback[0] = xKnockbackValue * -1;
        }
        if (playerMovement.getDirection() == Direction.right)
        {
            knockback[0] = xKnockbackValue;
        }
    }
}
