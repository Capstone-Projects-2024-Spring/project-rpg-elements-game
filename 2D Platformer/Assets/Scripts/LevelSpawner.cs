using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System.Linq;
using Mirror;

public class LevelSpawner : NetworkBehaviour
{
    private int M = 10;
    private int N = 10;
    bool gotRandom = false;
    private int[] mapVector;
    private int[,] mapMatrix;
    public GameObject[] rooms; //room prefabs 0 --> Open, 1 --> T, 2 --> L, 3 --> LT, 4 --> R, 5 --> TR, 6 --> LR, 7 --> LT, 8 --> B, 9 --> TB, 10 --> LB, 11 --> TLB, 12 --> RB, 13 --> TRB, 14 --> LBR, 15 --> LRTB    
    public int[,] roomTypes = {
        { 11, 9, 1, 1, 13, 3, 5, 7, 11, 5},
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
    public GameObject player1; // Player 1 spawn
    public float spawnPlayerRoom = 100; // Spawn Player room
    public int roomCounter = 0; // Room Counter for Spawning
    public int finalBossRoom = 1; // Final Boss Spawn Room
    public float roomWidth = 10f; // Width of the rooms
    public float roomHeight = 10f; // Height of the rooms
    public GameObject doorPrefab;
    public GameObject[] enemyPrefabs;

    public Transform spawnRoom; //room where user spawns

    //Spawn Player room
    public float spawnPlayerRoom = 100;

    //Room Counter for Spawning
    public int roomCounter = 0;

    //Final Boss Spawn Room
    public int finalBossRoom = 1;

    //Width and Height of the rooms
    public float roomWidth = 10f; 
    public float roomHeight = 10f;

    public void Start()
    { 
        SpawnRooms();  
    }

    public int getSpawnCounter()
    {
        return roomCounter;
    }

    async public void SpawnRooms()
    {
        gotRandom = await getRandomMap();
        vectorToMatrix();
        int numRows;
        int numCols;

        if (gotRandom)
        {
            roomTypes = mapMatrix;
            spawnPlayerRoom = mapVector[M * N];
            finalBossRoom = mapVector[M * N + 1];
            numRows = M;
            numCols = N;
        }
        else
        {
            numRows = roomTypes.GetLength(0);
            numCols = roomTypes.GetLength(1);
        }

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
                    //Debug.Log("Spawning room of type: " + roomType);
                    //Debug.Log("Room Location: " + newPos);
                    GameObject room = Instantiate(rooms[roomType], newPos, Quaternion.identity);
                    //Debug.Log("Room Counter: " + roomCounter);
                    roomCounter++;

                    SpawnEnemies(room, roomType);

                    if (isLocalPlayer)
                    {
                        if (roomCounter == spawnPlayerRoom)
                        {

                            Debug.Log("Room Location Final: " + newPos);

                            Instantiate(player1, newPos, Quaternion.identity);

                            //Locks Camera onto player
                            Cinemachine.CinemachineVirtualCamera virtualCamera = player1.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();

                            if (virtualCamera != null)
                            {
                                virtualCamera.enabled = true;
                            }
                        }
                    }
                }
            }
        }
    }

    private async Task<bool> getRandomMap()
    {
        mapVector = new int[M * N + 2];
        string data = "{ \"nargout\": 1, \"rhs\": [" + M.ToString() + "," + N.ToString() + "] }";
        UnityWebRequest www = UnityWebRequest.Post("www.meatdeathoftheuniverse.com:9900/mapGenerator/mapGenerator", data, "application/json");
        www.SendWebRequest();
        while (!www.isDone)
        {
            await Task.Yield();
        }

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
            gotRandom = false;
            return false;
        }
        else
        {
            Debug.Log("Form upload complete!");
            string response = www.downloadHandler.text;
            int start = 19;
            int end = response.Substring(start).IndexOf("]");
            int i = 0;
            int n;
            string mapString = response.Substring(start, end);
            if (mapString.Length == 1)
            {
                return false;
            }
            Debug.Log(mapString);
            foreach (var s in mapString.Split(','))
            {
                n = int.Parse(s);
                mapVector[i] = n;
                i++;
            }
            return true;
        }
    }
    private void vectorToMatrix()
    {
        mapMatrix = new int[M, N];
        int k = 0;
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                mapMatrix[i, j] = mapVector[k];
                k++;
            }
        }
    }

    public void SpawnEnemies(GameObject room, int roomType)
    {
        if (roomType == 8)
        {
            Transform[] enemySpawnPoints = room.GetComponentsInChildren<Transform>().Where(t => t.CompareTag("EnemySpawnPoint")).ToArray();

            int randEnemy = Random.Range(0, enemyPrefabs.Length);

            int randSpawnPoint = Random.Range(0, enemySpawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], enemySpawnPoints[randSpawnPoint].position, Quaternion.identity);
        }
    }

    public void SpawnDoor(GameObject room)
    {
        Vector2 roomPosition = room.transform.position;

        Vector2 doorSpawnPosition = new Vector2(roomPosition.x - roomWidth / 100f, roomPosition.y - roomHeight / 4f);

        GameObject door = Instantiate(doorPrefab, doorSpawnPosition, Quaternion.identity);

    }
}