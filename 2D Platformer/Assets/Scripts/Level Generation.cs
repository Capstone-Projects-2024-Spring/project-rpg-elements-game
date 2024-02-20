using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{   
    public Transform[] startingPositions;
    public GameObject[] rooms;

    private int direction;
    public float moveAmount;

    private float timeBetweenRoom;
    public float startTimeBetweenRoom = 0.25f;

    public float minX;
    public float maxX;
    public float minY;
    private bool stopGeneration;

    public LayerMask room;


    // Start is called before the first frame update
    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        
        direction = Random.Range(1, 6);
    }

    private void Move()
    {
        if(direction == 1 || direction ==2) {
            //This will prompt to move right

            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if(direction == 3)
                {
                    direction = 2;
                }
                else if(direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if(direction == 3 || direction ==4) {
            //This will prompt to move left

            if (transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);

            }
            else
            {
                direction = 5;
            }
        }
        else if(direction == 5){
            //This will prompt to move down

            if (transform.position.y > minY)
            {

                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if(roomDetection.GetComponent<RoomType>().type != 1&& roomDetection.GetComponent<RoomType>().type != 3)
                {
                    roomDetection.GetComponent<RoomType>().RoomDestruction();

                    int randBottomRoom = Random.Range(1, 4);
                    if(randBottomRoom == 2)
                    {
                        randBottomRoom = 1;
                    }
                    Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                }
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                stopGeneration = true;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(timeBetweenRoom <= 0 && stopGeneration == false){
            Move();
            timeBetweenRoom = startTimeBetweenRoom;
        }
        else
        {
            timeBetweenRoom-= Time.deltaTime;
        }
    }
}
