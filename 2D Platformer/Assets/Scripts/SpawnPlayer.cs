using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayerinLevel();
    }

    void SpawnPlayerinLevel()
    {
        Vector2 spawnPosition = new Vector2(6, 6);

        Instantiate(player1, spawnPosition, Quaternion.identity);

        Cinemachine.CinemachineVirtualCamera virtualCamera = player1.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();

        if (virtualCamera != null)
        {
            virtualCamera.enabled = true;
        }
    }
}
