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
                    Debug.Log(i);
                }
            }
        }

        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
