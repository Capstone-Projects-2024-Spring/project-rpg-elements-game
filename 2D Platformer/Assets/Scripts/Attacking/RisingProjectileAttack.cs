using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RisingProjectileAttack : RisingAttack
{
    [SerializeField] protected Vector2 spawnPosition;
    private float spawnXValue;

    [SerializeField] protected Vector2 projectileVelocity;

    private float velocityXValue;
    [SerializeField] protected float gravity = 0;

    [SerializeField] protected bool destroyOnContact = true;

    [SerializeField] protected float projectileLifetime = 2.0f;
    [SerializeField] protected bool collidesWithWalls = false;
    [SerializeField] protected Sprite sprite;
    [SerializeField] protected float projectileSize = 1;

    protected Hitbox storedProjectile;

    [SerializeField] Vector2 projectileHitboxModifiers = new Vector2(1, 1);
    // Start is called before the first frame update

    protected override void setKnockbackDirection()
    {
        if (playerMovement.getDirection() == Direction.left)
        {
            knockback[0] = xKnockbackValue * -1;
            spawnPosition[0] = spawnXValue * -1;
            projectileVelocity[0] = velocityXValue * -1;
        }
        if (playerMovement.getDirection() == Direction.right)
        {
            knockback[0] = xKnockbackValue;
            spawnPosition[0] = spawnXValue;
            projectileVelocity[0] = velocityXValue;
        }
    }
    protected override void setHitboxes()
    {
        foreach (Hitbox hitbox in hitboxes)
        {
            if (!hitbox.gameObject.activeSelf)
            {
                hitbox.setDamage(power + (int)statSheet.Strength.Value);
                hitbox.setKnockback(knockback);
                hitbox.setHitlag(hitlag);
                setHitboxVisibility(hitbox);
                storedProjectile = hitbox;
                return;
            }
        }
    }

    protected override void setHitboxVisibility(Hitbox hitbox)
    {
        if (visible_hitboxes)
        {
            hitbox.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0f, 0f, 0.5f);
        }
        else
        {
            hitbox.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

        }
    }

   
    protected override void setAttackName()
    {
        uses += 1;
        string attackUses = uses.ToString();
        string ID = attackName + attackUses;
        storedProjectile.setAttackID(ID);
    }

    protected override void Awake()
    {
        base.Awake();
        spawnXValue = spawnPosition[0];
        velocityXValue = projectileVelocity[0];
    }

    protected override void Update()
    {
        base.Update();
        if (!active)
        {
            return;
        }

    }

    protected override void burst()
    {
        if (!active)
        {
            return;
        }
        base.burst();
        //Debug.Log(projectileVelocity);

        storedProjectile.gameObject.transform.position = body.position + spawnPosition;
        storedProjectile.gameObject.SetActive(true);
        storedProjectile.gameObject.GetComponent<Projectile>().setProjectile(
            projectileVelocity, gravity, playerMovement.getDirection(), destroyOnContact,
            hitlag, projectileLifetime, collidesWithWalls, sprite, projectileSize, projectileHitboxModifiers);
        //Debug.Log(hitbox.getAttackID());
        //Debug.Log("Projectile ID: " + storedProjectile.getAttackID());

        return;

    }

    protected override void Deactivate()
    {
        //Debug.Log("Skyslash deactivated the attack!");
        active = false;
        success = false;
        playerMovement.setAttackStateFalse();
        body.gravityScale = stored_gravity;
        bursted = false;

    }

    protected virtual void SetActiveFalse()
    {
        if (!active)
        {
            return;
        }
        if (active)
        {
            active = false;
        }

    }

}
