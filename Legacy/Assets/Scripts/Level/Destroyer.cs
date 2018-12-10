using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomSpawn"))
        {   //Checks to see if any rooms spawn on top of the spawn room.

            Destroy(collision.gameObject);
            //Destroys the room ontop of the spawn room.
        }
            
    }
}
