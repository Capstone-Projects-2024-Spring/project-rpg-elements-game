using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] rooms; //room prefabs 0 --> Open, 1 --> T, 2 --> L, 3 --> LT, 4 --> R, 5 --> TR, 6 --> LR, 7 --> LT, 8 --> B, 9 --> TB, 10 --> LB, 11 --> TLB, 12 --> RB, 13 --> TRB, 14 --> LBR, 15 --> LRTB    
    public int[,] roomTypes = { { 11, 9, 1, 1, 13, 3, 5, 7, 11, 5},
        { 7, 11, 4, 14, 11, 8, 8, 0, 13, 6 },
        { 6, 3, 12, 3, 9, 13, 11, 4, 3, 12 },
        { 10, 8, 1, 12, 7, 3, 9, 0, 8, 5 },
        { 3, 13, 10, 5, 6, 6, 3, 0, 1, 12 },
        { 10, 1, 5, 6, 6, 6, 14, 6, 2, 13},
        { 11, 12, 2, 8, 0, 12, 3, 8, 8, 5 },
        { 3, 9, 4, 11, 4, 3, 8, 1, 1, 4},
        { 6, 3, 8, 1, 12, 2, 1, 4, 6,6},
        { 10, 12, 11, 8, 9, 12, 14, 10, 12, 14}
    }; //Matrix that will be made by algorithm
    public Transform spawnPoint; // Spawn point for where rooms can spawns

    //Spawn Player room
    public int spawnPlayerRoom = 17;

    //Final Boss Spawn Room
    public int finalBossRoom = 2;

    //Width and Height of the rooms
    public float roomWidth = 10f; 
    public float roomHeight = 10f; 

    void Start()
    {
        SpawnRooms();
    }

    void SpawnRooms()
    {
        int numRows = roomTypes.GetLength(0);
        int numCols = roomTypes.GetLength(1);

        //Iterate through matrix
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                int roomType = roomTypes[i, j];

                if (roomType >= 0 && roomType < rooms.Length)
                {
                    Vector2 newPos = new Vector2(j * roomWidth, -i * roomHeight);

                    // Ensure the correct rooms are spawning
                    Debug.Log("Spawning room of type: " + roomType);

                    GameObject room = Instantiate(rooms[roomType], newPos, Quaternion.identity);
                    
                }
            }
        }
    }
}