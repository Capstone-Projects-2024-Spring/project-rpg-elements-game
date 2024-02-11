using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    //
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Enemy")){
            //Damage the enemy
            print("u hit the enemy :(((((");
        }

    }
}
