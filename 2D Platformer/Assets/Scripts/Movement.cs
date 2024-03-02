using System;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
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

    private Direction facing = Direction.right;
    [SerializeField] private float friction = 1;

    private bool isWallSliding;
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 3.5f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    private void Start(){
        //Grabs references for Rigidbody, Box Collider, and Animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.sharedMaterial.friction = 1;


    }

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
                //Set animator parameters
        anim.SetBool("run", (horizontalInput != 0));
        anim.SetBool("grounded", isGrounded());



        

        //Debug.Log(attacking);
        if(attacking){
            return;
        }
        //Makes the player move left/right
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * statSheet.Speed.Value, body.velocity.y);

    


        
        //Makes the player jump when space is pressed
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
            Jump();
        }

        if(onWall() && body.velocity.x != 0){
            boxCollider.sharedMaterial.friction = 0;
            body.velocity = new Vector2(0, -1 * Math.Abs(wall_sliding_speed));
            isWallSliding = true;
        }
        else{
            boxCollider.sharedMaterial.friction = friction;
            isWallSliding = false;
        }
        WallJump();

        //Flips sprite when turning left/right
        //Is supposed to not turn the player if in the middle of a wall jump
        if(!isWallJumping){
            if(horizontalInput > 0.01f){
                transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                facing = Direction.right;
            }else if(horizontalInput < -0.01f){
                transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
                facing = Direction.left;
            }
        }
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jump_height);
        anim.SetTrigger("jump");

    }

    public bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer); 
        return raycastHit.collider != null;
    }

    private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer); 
        return raycastHit.collider != null;
    }

    public bool canAttack(){
        return !attacking;
    }

    public void setAttackStateTrue(){
        attacking = true;
    }

    public void setAttackStateFalse(){
        attacking = false;
    }

    public Direction getDirection(){
        return facing;
    }

    public float getFriction(){
        return friction;
    }

    public void setFriction(float _friction){
        boxCollider.sharedMaterial.friction = _friction;
    }
    
    private void WallJump()
    {

        if (isWallSliding)
        {
            isWallJumping = false;
            //Sets direction opposite of direction of wall
            wallJumpingDirection = -transform.localScale.x;
            //Gives time for player to turn away then jump
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            Debug.Log("Wall Jumped!");
            isWallJumping = true;
            body.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }

        
    }
    private void StopWallJumping()
    {
        isWallJumping = false;
    }


}
