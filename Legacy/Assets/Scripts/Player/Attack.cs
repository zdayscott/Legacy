using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public int damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTrigger");
        Debug.Log(this.gameObject.GetComponentInParent<GameObject>().tag);
        if(collision.gameObject.tag == "Enemy" && this.gameObject.GetComponentInParent<GameObject>().tag == "Player")
        {
            Debug.Log("Player Attacking Enemy!");
            collision.GetComponent<EnemyStats>().TakeDamage(damage);
        }

        if(collision.gameObject.tag == "Player" && this.gameObject.GetComponentInParent<GameObject>().tag == "Enemy")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger Stay");
    }
}
