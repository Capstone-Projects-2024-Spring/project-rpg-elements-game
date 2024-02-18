using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected LayerMask wallLayer;
    protected float speedMod;
    protected float baseSpeed = 10.0f;
    protected Rigidbody2D body;
    protected Animator anim;
    protected BoxCollider2D boxCollider;
    protected Direction facing;
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
}