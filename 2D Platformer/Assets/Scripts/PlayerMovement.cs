using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected float baseJump = 10.0f;
    protected bool attacking = false;
    protected virtual float jumpMod => 0;

    protected override void Awake()
    {
        //Grabs references for Rigidbody, Box Collider, and Animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        facing = Direction.right;
    }

    protected override void Update()
    {
        Move();
    }

    protected override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Makes the player move left/right
        if (attacking == false)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * (baseSpeed + speedMod), body.velocity.y);
        }

        //Flips sprite when turning left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            facing = Direction.right;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            facing = Direction.left;
        }

        //Makes the player jump when space is pressed
        if (Input.GetKey(KeyCode.Space) && isGrounded() && (attacking == false))
        {
            Jump();
        }

        //Set animator parameters
        anim.SetBool("run", (horizontalInput != 0) && (attacking == false));
        anim.SetBool("grounded", isGrounded());
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, baseJump + jumpMod);
        anim.SetTrigger("jump");
    }

    private bool isGrounded()
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
        return !attacking;
    }

    private void setAttackStateTrue()
    {
        attacking = true;
    }

    private void setAttackStateFalse()
    {
        attacking = false;
    }

    public Direction getDirection()
    {
        return facing;
    }
}