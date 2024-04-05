using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System;

public class Door : NetworkBehaviour
{
    public Vector2 bossPosition;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("Switching Locations");

            movePlayer(bossPosition);
        }
    }

    [ClientRpc]
    private void movePlayer(Vector2 bossPosition)
    {
        player.transform.position = bossPosition;
    }
}
