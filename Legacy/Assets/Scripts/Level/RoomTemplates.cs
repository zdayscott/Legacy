using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    public GameObject[] leftRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;
    public GameObject[] enemies;

    public float xOffset = 20f;
    public float yOffset = 10f;

    void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    GameObject b = Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    b.tag = "Boss";
                    spawnedBoss = true;
                }
                else
                {
                    int diff = i * GM.instance.currentFloor;
                    EnemySpawner(Random.Range(i,diff), rooms[i].transform);
                }
            }
        }

        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void EnemySpawner(int difficulty, Transform roomCenter)
    {
        List<GameObject> enemiesInRoom = new List<GameObject>();

        while(difficulty >= 0)
        {
            enemiesInRoom.Add(enemies[Random.Range(0, enemies.Length)]);
            difficulty -= 1;
        }

        foreach(GameObject e in enemiesInRoom)
        {
            Vector3 offset = new Vector3(Random.Range(-xOffset, xOffset), Random.Range(-yOffset, yOffset), 0);
            Instantiate(e, roomCenter.position + offset, Quaternion.identity);
        }
    }
}
