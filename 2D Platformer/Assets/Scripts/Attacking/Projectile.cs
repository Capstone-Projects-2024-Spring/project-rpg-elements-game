using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    private bool fired = false;
    private Vector2 velocity = new Vector2(0, 0);

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private bool destroyOnContact = false;
    private bool hit = false;
    private float hitlagTimer = 0.0f;
    private float lifetime = 0.0f;
    private float lifetimeTimer = 0.0f;
    private double hitlag;

    private bool hasGravity = false;

    private bool setVelocity = false;
    private bool collidesWithWalls = false;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {
        if(fired){
            lifetimeTimer += Time.deltaTime;
        }
        if(!hasGravity || !setVelocity){
            body.velocity = velocity;
            setVelocity = true;

        }
        if(lifetimeTimer >= lifetime){
            destroy();
        }
        if(hit){
            hitlagTimer += Time.deltaTime;
        }
        if(hitlagTimer < hitlag){
            return;
        }
        if(destroyOnContact){
            destroy();
        }
        resetHitlagValues();
        
        
    }

    private void destroy(){
        resetHitlagValues();
        gameObject.SetActive(false);
        fired = false;
        lifetimeTimer = 0;
        setVelocity = false;
        hasGravity = false;

    }

    private void resetHitlagValues(){
        hitlagTimer = 0.0f;
        hit = false;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;


    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Wall" || other.tag == "Ground"){
            if(!collidesWithWalls){
            return;
            }
        }
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        hit = true;
        

        
        
    }

    public void setProjectile(Vector2 _velocity, float _gravity, Direction _direction, bool _destroyOnContact, 
    double _hitlag, float _lifetime, bool _collidesWithWalls, Sprite _sprite, float _scale){
        velocity = _velocity;
        body.gravityScale = _gravity;
        //boxCollider.enabled = true;
        fired = true;
        destroyOnContact = _destroyOnContact;
        transform.localScale = new Vector3(_scale, _scale, _scale);
        if(_direction == Direction.left){
            transform.localScale= new Vector3(Math.Abs(transform.localScale[0]) * -1, transform.localScale[1], transform.localScale[2]);
        }
        if(_direction == Direction.right){
            transform.localScale= new Vector3(Math.Abs(transform.localScale[0]), transform.localScale[1], transform.localScale[2]);
        }
        hitlag = _hitlag;
        lifetime = _lifetime;
        if(_gravity != 0){
            hasGravity = true;
        }
        collidesWithWalls = _collidesWithWalls;
        spriteRenderer.sprite = _sprite;

    }

    
}
