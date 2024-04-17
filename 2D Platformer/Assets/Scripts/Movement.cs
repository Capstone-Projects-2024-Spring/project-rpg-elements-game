using System;
using Unity.VisualScripting;
using UnityEngine;
using Mirror;


public class Movement : NetworkBehaviour
{
    [SerializeField] private PlayerStats statSheet;
    [SerializeField] private float jump_height;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float wall_sliding_speed = -3;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool attacking = false;
    private bool hurt = false;
    private bool sentForwards = false;
    private float hitstunTimer = 0f;
    private Direction facing = Direction.right;
    [SerializeField] private float friction = 1;

    /*[Command]
    public void CmdFlipSprite(){
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            facing = Direction.right;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
            facing = Direction.left;
        }
    }*/

    private void Start()
    {
         //Grabs references for Rigidbody, Box Collider, and Animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.sharedMaterial.friction = 1;

    }

    [ClientCallback]
    private void Update()
    {
        if (!isOwned) { return; }


        float horizontalInput = Input.GetAxis("Horizontal");
        //Set animator parameters
        anim.SetBool("run", (horizontalInput != 0));
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("hurt", hurt);
        anim.SetBool("sent_forwards", sentForwards);

        if (hitstunTimer <= 0f)
        {
            hurt = false;
            boxCollider.sharedMaterial.bounciness = 0.0f;
        }

        if (hurt)
        {
            hitstunTimer -= Time.deltaTime;
            return;
        }
        //Debug.Log(attacking);
        if (attacking)
        {
            return;
        }
        //Makes the player move left/right
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * statSheet.Speed.Value, body.velocity.y);

        //Flips sprite when turning left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            facing = Direction.right;
            //CmdFlipSprite();
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
            facing = Direction.left;
            //CmdFlipSprite();
        }

        //Makes the player jump when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
        }

        if (onWall())
        {
            boxCollider.sharedMaterial.friction = 0;
            body.velocity = new Vector2(0, -1 * Math.Abs(wall_sliding_speed));
        }
        else
        {
            boxCollider.sharedMaterial.friction = friction;
        }
        //Debug.Log(boxCollider.sharedMaterial.friction);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_height);
        anim.SetTrigger("jump");

    }

    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        if (hurt)
        {
            return false;
        }
        return !attacking;
    }
    public void setAttackStateTrue()
    {
        attacking = true;
    }

    public void setAttackStateFalse()
    {
        attacking = false;
    }

    public void setHurtStateTrue(float _hitstunTimer, float xKnockback)
    {
        //boxCollider.sharedMaterial.bounciness = 1f;
        hurt = true;
        hitstunTimer = _hitstunTimer;
        if ((xKnockback >= 0 && getDirection() == Direction.right) || (xKnockback < 0 && getDirection() == Direction.left))
        {
            sentForwards = true;
        }
        else
        {
            sentForwards = false;
        }
    }

    public Direction getDirection()
    {
        return facing;
    }

    public float getFriction()
    {
        return friction;
    }

    public void setFriction(float _friction)
    {
        boxCollider.sharedMaterial.friction = _friction;
    }
}
