using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : PlayerAttack
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

    
    //[SerializeField] protected Projectile[] projectiles;
    protected override void Awake(){
        base.Awake();
        spawnXValue = spawnPosition[0];
        velocityXValue = projectileVelocity[0];
    }
    protected override void Update(){
        base.Update();
        if(!active){
            return;
        }
        
    }
    protected override void setHitboxVisibility(Hitbox hitbox){
        if(visible_hitboxes){
            hitbox.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0f,0f,0.5f);
        }else{
            hitbox.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);

        }
    }

    protected override void setKnockbackDirection(){
        if(playerMovement.getDirection() == Direction.left){
            knockback[0] = xKnockbackValue * -1;
            spawnPosition[0] = spawnXValue * -1;
            projectileVelocity[0] = velocityXValue * -1;
        }
        if(playerMovement.getDirection() == Direction.right){
            knockback[0] = xKnockbackValue;
            spawnPosition[0] = spawnXValue;
            projectileVelocity[0] = velocityXValue;
        }
    }

    protected virtual void ActivateProjectile(){
        if(!active){
            return;
        }
        foreach(Hitbox hitbox in hitboxes){
            if(!hitbox.gameObject.activeSelf){
                hitbox.gameObject.transform.position = body.position + spawnPosition;
                hitbox.gameObject.SetActive(true);
                hitbox.gameObject.GetComponent<Projectile>().setProjectile(
                    projectileVelocity, gravity, playerMovement.getDirection(), destroyOnContact, 
                    hitlag, projectileLifetime, collidesWithWalls, sprite, projectileSize);
                Debug.Log(hitbox);
                return;
            }
        }

    }

    protected virtual void SetActiveFalse(){
        if(!active){
            return;
        }
        if(active){
            active = false;
        }

    }
    
}
