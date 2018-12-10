using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour {

    public int openingDirection;
    // 1 --> need left door
    // 2 --> need bottom door
    // 3 --> need right door
    // 4 --> need top door

    private RoomTemplates templates;
    //To access the rooms added in the room templates script
    private int rand;
    //To obatin a random value which represents a room for each opening direction.
    private bool spawned;
    //To see if a room has already been spawned in order to prevent any other rooms from spawning on top of one another.

    public float waitTime = 4f;
    //This variables is utilized to set the time after a room is spawned to destoy the spawn game object.

    void Start()
    {
        Destroy(gameObject, waitTime); //This destroys the spawn game object.
        //Debug.Log("Room Start" + this.gameObject.name); !TESTING!
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>(); //This access the rooms with the tag "Rooms" and places it in a variable called templates.
        //Debug.Log("Templates Found" + this.gameObject.name); !TESTING!
        Invoke("Spawn", 0.3f); //This function waits about .3 second during the initial spawning process in order to run the game easier.
        //Debug.Log("Spawn Called" + this.gameObject.name);!TESTING!
    }

    void Spawn()
    {
        if(spawned == false)
        {
            if(openingDirection == 1)
            {   //Need a room with left door 
                rand = Random.Range(0, templates.leftRooms.Length); //This chooses a random room from the left doors array.
                transform.position = new Vector3(transform.position.x, transform.position.y, 0); //This makes sure the room spawned stays on the same z-axis as the rest of the rooms
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation); //This will spawn that room with the given position and standard rotation.
                //Debug.Log(transform.position);
            }
            else if (openingDirection == 2)
            {   //Need a room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length); //This chooses a random room from the bottom doors array.
                transform.position = new Vector3(transform.position.x, transform.position.y, 0); //This makes sure the room spawned stays on the same z-axis as the rest of the rooms
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation); //This will spawn that room with the given position and standard rotation.
                //Debug.Log(transform.position);
            }
            else if (openingDirection == 3)
            {   //Need a room with right door
                rand = Random.Range(0, templates.rightRooms.Length); //This chooses a random room from the right doors array.
                transform.position = new Vector3(transform.position.x, transform.position.y, 0); //This makes sure the room spawned stays on the same z-axis as the rest of the rooms
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation); //This will spawn that room with the given position and standard rotation.
                //Debug.Log(transform.position);
            }
            else if (openingDirection == 4)
            {   //Need a room with top door
                rand = Random.Range(0, templates.topRooms.Length); //This chooses a random room from the top doors array.
                transform.position = new Vector3(transform.position.x, transform.position.y, 0); //This makes sure the room spawned stays on the same z-axis as the rest of the rooms
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation); //This will spawn that room with the given position and standard rotation.
                //Debug.Log(transform.position);
            }
            spawned = true; 
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {   // This function makes sure that there are no rooms that spawn on top of one another.
        if (collider.GetComponent<RoomGeneration>() != null)
        {   //This checks to see if there is a room on the field.
            if (collider.CompareTag("RoomSpawn"))
            {   //This is to get the rooms on the field because they are marked with a tag.
                if (collider.GetComponent<RoomGeneration>().spawned == false && spawned == false)
                {   //Checks to see that if the room collided has not been collided yet
                    Destroy(gameObject);
                    //Then it destroys the current room that was waiting to be spawned.
                }
                spawned = true;
                //Then this sets to variable to be true so that no other rooms can collide with it.
            }
        }
    }
}

/*             if(collider.GetComponent<RoomGeneration>() == null)
            {
                //Debug.Log("RoomG is null");
                return;
            }

            if(collider.GetComponent<RoomGeneration>().spawned == false && spawned == false)
*/