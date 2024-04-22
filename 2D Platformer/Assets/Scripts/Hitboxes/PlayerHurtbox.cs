using UnityEngine;

public class PlayerHurtbox : Hurtbox
{
    protected Movement movement;

    [SerializeField] PlayerStats playerStatSheet;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponentInChildren<Hurtbox>().getHitstun())
            {
                Debug.Log("Skrake is hurt, not taking knockback");
                return;
            }
            Debug.Log("I am touching an enemy");
            Debug.Log(body);

            attacked = true;
            if (this.transform.position.x < other.gameObject.transform.position.x)
            {
                takenKnockback[0] = -7.0f;
            }
            else if (this.transform.position.x >= other.gameObject.transform.position.x)
            {
                takenKnockback[0] = 7.0f;
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

    protected override void LowerHealth()
    {
        takenDamage = 0;

    }

    public PlayerStats getStatSheet()
    {
        return playerStatSheet;
    }
}

