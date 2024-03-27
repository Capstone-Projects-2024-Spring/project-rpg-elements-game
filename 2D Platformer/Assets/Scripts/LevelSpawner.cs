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
    private int minDim = 10;
    private int maxDim = 20;
    private int numRows;
    private int numCols;
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

    public Transform spawnRoom; //room where user spawns
    public Transform spawnPoint; // Spawn point for where rooms can spawns
    public GameObject player1; // Player 1 spawn
    public GameObject doorPrefab;
    public GameObject[] enemyPrefabs;
    public float spawnPlayerRoom = 100; // Spawn Player room
    public int roomCounter = 0; // Room Counter for Spawning
    public int finalBossRoom = 1; // Final Boss Spawn Room
    public float roomWidth = 10f; // Width of the rooms
    public float roomHeight = 10f; // Height of the rooms
    public Vector2 newPos;


    public override void OnStartServer()
    {
        base.OnStartServer();
        SpawnRooms();
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (isLocalPlayer)
        {
            SpawnPlayer();
        }
    }
    public int getSpawnCounter()
    {
        return roomCounter;
    }

    async public void SpawnRooms()
    {
        numRows = Random.Range(minDim, maxDim);
        numCols = Random.Range(minDim, maxDim);
        //numRows = 10;
        //numCols = 10;
        gotRandom = await getRandomMap();
        vectorToMatrix();

        if (gotRandom)
        {
            roomTypes = mapMatrix;
            spawnPlayerRoom = mapVector[numRows * numCols];
            finalBossRoom = mapVector[numRows * numCols + 1];
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
                    newPos = new Vector2(j * roomWidth, -i * roomHeight);
                    // Ensure the correct rooms are spawning
                    GameObject room = Instantiate(rooms[roomType], newPos, Quaternion.identity);
                    roomCounter++;
                    NetworkServer.Spawn(room);
                    SpawnEnemies(room, roomType);
                    if (roomCounter == spawnPlayerRoom)
                    {
                        if (isLocalPlayer)
                        {
                            Instantiate(player1, newPos, Quaternion.identity);
                            Vector2 spawnPos = GetSpawnPosition(newPos, out bool isLocalPlayerSpawn);

                            GameObject player = Instantiate(player1, spawnPos, Quaternion.identity);
                            NetworkServer.Spawn(player);
                            CinemachineVirtualCamera virtualCamera = player.GetComponentInChildren<CinemachineVirtualCamera>();

                            if (virtualCamera != null)
                            { 
                                virtualCamera.enabled = true;
                            }
                        }
                    }
                    if (roomCounter == finalBossRoom)
                    {
                        SpawnDoor(room);
                    }
                }
            }
        }
    }

    private async Task<bool> getRandomMap()
    {
        mapVector = new int[numRows * numCols + 2];
        string data = "{ \"nargout\": 1, \"rhs\": [" + numRows.ToString() + "," + numCols.ToString() + "] }";
        UnityWebRequest www = UnityWebRequest.Post("www.meatdeathoftheuniverse.com:9900/mapGenerator/mapGenerator", data, "application/json");
        www.SendWebRequest();
        while (!www.isDone)
        {
            await Task.Yield();
        }

        if (www.result != UnityWebRequest.Result.Success)
        {
            gotRandom = false;
            return false;
        }
        else
        {
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
        mapMatrix = new int[numRows, numCols];
        int k = 0;
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
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
            GameObject enem=Instantiate(enemyPrefabs[randEnemy], enemySpawnPoints[randSpawnPoint].position, Quaternion.identity);
            NetworkServer.Spawn(enem);
        }
    }

    public void SpawnDoor(GameObject room)
    {
        Vector2 roomPosition = room.transform.position;
        Vector2 doorSpawnPosition = new Vector2(roomPosition.x - roomWidth / 100f, roomPosition.y - roomHeight / 4f);
        GameObject door = Instantiate(doorPrefab, doorSpawnPosition, Quaternion.identity);
        NetworkServer.Spawn(door);
    }

    private Vector2 GetSpawnPosition(Vector2 newPos, out bool isLocal)
    {
        Vector2 spawnPos = newPos; 
        isLocal = isLocalPlayer && roomCounter == spawnPlayerRoom;
        return spawnPos;
    }

    [Command]
    private void SpawnPlayer()
    {
        bool isLocalPlayerSpawn;
        Vector2 spawnPos = GetSpawnPosition(newPos, out isLocalPlayerSpawn);

        GameObject player = Instantiate(player1, spawnPos, Quaternion.identity);
        NetworkServer.Spawn(player, connectionToClient);

        if (isLocalPlayerSpawn)
        {
            CinemachineVirtualCamera virtualCamera = player.GetComponentInChildren<CinemachineVirtualCamera>();
            if (virtualCamera != null)
            {
                virtualCamera.enabled = true;
            }
        }
    }

    public int getNumRows()
    {
        return numRows;
    }
    public int getNumCols()
    {
        return numCols;
    }
    public bool setNumRows(int M)
    {
        if (M >= minDim && M <= maxDim)
        {
            numRows = M;
            return true;
        }
        return false;
    }
    public bool setNumCols(int N)
    {
        if (N >= minDim && N <= maxDim)
        {
            numCols = N;
            return true;
        }
        return false;
    }
}