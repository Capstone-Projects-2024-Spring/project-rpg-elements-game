using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float running_speed;
    [SerializeField] private float jump_height;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool attacking = false;

    private Direction facing = Direction.right;

    private void Awake(){
        //Grabs references for Rigidbody, Box Collider, and Animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        

    }

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        //Makes the player move left/right
        if(attacking == false){
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * running_speed, body.velocity.y);
        }

        //Flips sprite when turning left/right
        if(horizontalInput > 0.01f && !attacking){
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            facing = Direction.right;
        }else if(horizontalInput < -0.01f && !attacking){
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            facing = Direction.left;
        }
        
        //Makes the player jump when space is pressed
        if(Input.GetKey(KeyCode.Space) && isGrounded() && (attacking == false)){
            Jump();
        }



        //Set animator parameters
        anim.SetBool("run", (horizontalInput != 0) && (attacking == false));
        anim.SetBool("grounded", isGrounded());
    

 
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jump_height);
        anim.SetTrigger("jump");
    }

    private bool isGrounded(){
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

    




}
