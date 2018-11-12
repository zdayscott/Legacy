using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public int damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger Stay");
    }
}
