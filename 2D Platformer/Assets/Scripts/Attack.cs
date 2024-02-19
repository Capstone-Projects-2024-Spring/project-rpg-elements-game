using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : MonoBehaviour
{
    protected Animator anim;
    public float[] knockback;
    protected float xKnockbackValue;
    public Hitbox[] hitboxes;
    protected int uses = 0;
    protected double hitlag;
    protected bool success;
    protected bool active;
    protected float time = 0.0f;
    protected string receiverID = "";
    protected Rigidbody2D body;
    protected Vector2 storedVelocity = new Vector2();
    public virtual int power => 0;
    protected virtual string attackName => "";
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponentInParent<Rigidbody2D>();
        xKnockbackValue = Math.Abs(knockback[0]);
        hitlag = setHitlag(knockback[0], knockback[1]);
        setHitboxes();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        checkHit();
    }

    protected virtual void FixedUpdate()
    {

    }

    protected void setHitboxes()
    {
        foreach (Hitbox hitbox in hitboxes)
        {
            hitbox.setDamage(power);
            hitbox.setKnockback(knockback);
            hitbox.setHitlag(hitlag);
        }
    }

    protected void checkHit()
    {
        setKnockbackDirection();
        if (active)
        {
            checkSuccess();
        }
        if (success)
        {
            //Debug.Log("Landed a hit!");
            enterHitlag();
            success = false;
        }

        if (anim.enabled == false)
        {
            time += Time.deltaTime;
            //Debug.Log(time);
            if (time > hitlag)
            {
                anim.enabled = true;
                body.constraints = RigidbodyConstraints2D.FreezeRotation;
                body.velocity = storedVelocity;
                //Debug.Log("No longer in hitlag");
            }
        }
    }
    protected void checkSuccess()
    {
        int hits = 0;
        foreach (Hitbox hitbox in hitboxes)
        {
            if (hitbox.getSuccess() && !string.Equals(hitbox.getReceiverID(), receiverID))
            {
                hits += 1;
                receiverID = hitbox.getReceiverID();
                //Debug.Log(receiverID);
            }
        }
        if (hits > 0)
        {
            success = true;
        }
    }

    protected void setAttackName()
    {
        uses += 1;
        String attackUses = uses.ToString();
        String ID = attackName + attackUses;
        foreach (Hitbox hitbox in hitboxes)
        {
            hitbox.setAttackID(ID);
            //Debug.Log(hitbox.getAttackID());
        }
    }

    protected double setHitlag(float xknockback, float yknockback)
    {
        double calculated_hitlag = (Math.Sqrt(Math.Pow(Math.Abs(xknockback), 2) + Math.Pow(Math.Abs(yknockback), 2)) * 0.65 + 6) / 60;
        if (calculated_hitlag > 0.5) { calculated_hitlag = 0.5; }
        return calculated_hitlag;
    }

    protected void enterHitlag()
    {
        time = 0;
        anim.enabled = false;
        storedVelocity = body.velocity;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        //Debug.Log(storedVelocity);
    }

    protected virtual void setKnockbackDirection()
    {
    
    }

    protected void attack()
    {
        anim.SetTrigger("attack");
    }


    protected void ActivateHitbox()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        active = true;
    }

    protected void DeactivateHitbox()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        active = false;
        success = false;
        foreach (Hitbox hitbox in hitboxes)
        {
            hitbox.setSuccess(false);
        }
    }
}