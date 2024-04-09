using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAttack : PlayerAttack
{
    [SerializeField] protected Vector2 burstVelocity;

    protected void boost()
    {
        if (!active)
        {
            return;
        }
        body.velocity = burstVelocity;
    }

    protected override void setKnockbackDirection()
    {
        if (playerMovement.getDirection() == Direction.left)
        {
            knockback[0] = xKnockbackValue * -1;
            burstVelocity = new Vector2(Math.Abs(burstVelocity.x) * -1, burstVelocity.y);
            
        }
        if (playerMovement.getDirection() == Direction.right)
        {
            knockback[0] = xKnockbackValue;
            burstVelocity = new Vector2(Math.Abs(burstVelocity.x), burstVelocity.y);

        }
    }

}
