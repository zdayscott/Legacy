using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

    private RoomTemplates templates;
    //To access the rooms from Room Templates

    void Start()
    {
        //To find the rooms with the tag "Rooms"
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        //To find all the rooms that were spawned onto the scene
        templates.rooms.Add(this.gameObject);
    }
}
