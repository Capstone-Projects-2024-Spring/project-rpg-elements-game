using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System;

public class Door : NetworkBehaviour
{
    public Vector2 bossPosition = new Vector2(-78.5f, -18.5f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("Switching Locations");

            movePlayer(other.gameObject);
        }
    }

   
    private void movePlayer(GameObject player)
    {
        player.transform.position = bossPosition;
    }
}
