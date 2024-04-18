using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class myNetworkManager : NetworkManager
{
    public GameObject[] playerPrefabs;
    private int n = 0;

    public override void OnStartServer()
    {
        base.OnStartServer();
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject playerPrefab = DeterminePlayerPrefab();

        GameObject player = Instantiate(playerPrefab);

        NetworkServer.AddPlayerForConnection(conn, player);
    }
    
    GameObject DeterminePlayerPrefab()
    {
        GameObject prefab = playerPrefabs[n];

        n = (n + 1) % playerPrefabs.Length;

        return prefab;
    }
}