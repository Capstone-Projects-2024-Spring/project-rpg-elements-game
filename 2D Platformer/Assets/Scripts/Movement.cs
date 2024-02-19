using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected LayerMask wallLayer;
    protected Animator anim;
    protected Rigidbody2D body;
    protected BoxCollider2D boxCollider;
    protected Direction facing;
    protected float baseSpeed = 10.0f;
    protected virtual float speedMod => 0;
    protected virtual void Start()
    {

    }

    protected virtual void Awake()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual void Move()
    {

    }

    protected virtual void Jump()
    {
        
    }
}