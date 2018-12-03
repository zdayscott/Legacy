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
    private int rand;
    private bool spawned;

    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject, waitTime);
        Debug.Log("Room Start" + this.gameObject.name);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Debug.Log("Templates Found" + this.gameObject.name);
        Invoke("Spawn", 0.3f);
        Debug.Log("Spawn Called" + this.gameObject.name);
    }

    void Spawn()
    {
        if(spawned == false)
        {
            if(openingDirection == 1)
            {   //Need a room with left door 
                rand = Random.Range(0, templates.leftRooms.Length);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                Debug.Log(transform.position);
            }
            else if (openingDirection == 2)
            {   //Need a room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                Debug.Log(transform.position);
            }
            else if (openingDirection == 3)
            {   //Need a room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                Debug.Log(transform.position);
            }
            else if (openingDirection == 4)
            {   //Need a room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                Debug.Log(transform.position);
            }
            spawned = true; 
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("RoomSpawn"))
        {
            if(collider.GetComponent<RoomGeneration>().spawned == false && spawned == false)
            {
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
