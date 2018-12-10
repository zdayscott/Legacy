using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    //These arrays you can access through the inspector, changing the amount of types of rooms that can spawn.
    //Keep in mind the more different type of rooms in each array, the larger the level will be.
    //Another note, you can added the same types of rooms in each array in order to increase there chances of getting spawned. This should have no effect on the level size.

    public GameObject[] leftRooms; //An array of doors that open from the left side. This array should be filled up with rooms that have RIGHT doors.
    public GameObject[] bottomRooms; //An array of doors that open from the left side. This array should be filled up with rooms that have TOP doors.
    public GameObject[] rightRooms; //An array of doors that open from the left side. This array should be filled up with rooms that have LEFT doors.
    public GameObject[] topRooms; //An array of doors that open from the left side. This array should be filled up with rooms that have BOTTOM doors.

    public List<GameObject> rooms; //This is for the rooms that will spawn on the scene

    public float waitTime; //This is the wait time for the boss to spawn after all the other rooms have spawned
    private bool spawnedBoss; //This checks to see if the boss has spawned.
    public GameObject boss; //You could essentially place any entity here to represent the boss room.

    void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {   //This checks to see if the current room is anything but the last room
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {   //This finds the last room that spawns at the end
                    GameObject b = Instantiate(boss, rooms[i].transform.position, Quaternion.identity); //This places the entity in the center of the last room with standard position and rotaion.
                    b.tag = "Boss"; //This makes sure that the entity placed is a boss but you could change to any other entity you wish.
                    spawnedBoss = true; //This sets the boss variable to true so that no other boss can spawn.
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime; //This essentially makes sure all rooms have spawned before we place a boss onto the level. 
        }
    }
}
