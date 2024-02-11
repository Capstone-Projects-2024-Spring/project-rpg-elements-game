using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private IHitboxResponder _responder = null;
    public int damage = 2;
/*
    public LayerMask mask;
    public Vector2 hitboxSize = Vector2.one;
    public float radius = 0.5f;
    public Color inactiveColor;
    public Color collisionOpenColor;
    public Color collidingColor;
    
    private ColliderState _state;

    public Transform attackPoint;
    public float attackRange = 0.5f;
*/


   

    private void Awake(){
        Debug.Log("Hello");

        
    }

    private void Update(){
    /*
        if (_state == ColliderState.Closed){
            Debug.Log("No colliding state here!");
            return;}
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale/2, Quaternion.identity, mask);

        for(int i = 0; i < colliders.Length; i++){
            Debug.Log("We hit something!");
            Collider aCollider = colliders[i];
            _responder?.collisionedWith(aCollider);
        }
    */
    }

    public void useResponder(IHitboxResponder responder){
        _responder = responder;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EnemyHurtbox"){
            Debug.Log("DEAL " + damage + " DAMAGE TO " + other.name);
        }
    }

/* Unused functions because I currently can't figure out how to use them

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector2.zero, new Vector2(attackRange * 2, attackRange * 2));
    }

    private void checkGizmoColor(){
        switch (_state){
            case ColliderState.Closed:
                Gizmos.color = inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = collidingColor;
                break;
        }
    }

    public void startCheckingCollision(){
        _state = ColliderState.Open;

    }
    public void stopCheckingCollision(){
        _state = ColliderState.Closed;
        
    }
    */


    
}
