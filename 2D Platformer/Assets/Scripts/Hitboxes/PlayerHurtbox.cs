using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerHurtbox : Hurtbox
{
    protected Movement movement;

    [SerializeField] PlayerStats playerStatSheet;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("I am touching an enemy");
            Debug.Log(body);

            attacked = true;
            if (movement.getDirection() == Direction.left)
            {
                takenKnockback[0] = 7.0f;
            }
            if (movement.getDirection() == Direction.right)
            {
                takenKnockback[0] = -7.0f;
            }
            takenKnockback[1] = 7.0f;
            takenHitlag = 0.3f;
            movement.setHurtStateTrue(0.8f, takenKnockback[0]);



        }
    }

    protected override void Awake()
    {
        base.Awake();
        body = GetComponentInParent<Rigidbody2D>();
        movement = GetComponentInParent<Movement>();
    }

    public PlayerStats getStatSheet()
    {
        return playerStatSheet;
    }
}

