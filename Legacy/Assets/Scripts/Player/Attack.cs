using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public int damage = 5;
    public GameObject player;
    private List<Collider2D> enemiesHit = new List<Collider2D>();
    private bool attacking;

    private void Start()
    {
        attacking = false;

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss") && !enemiesHit.Contains(collision))
        {
            Debug.Log("Attacking: " + collision.gameObject.name);
            collision.GetComponent<EnemyStats>().TakeDamage(damage, player);
            enemiesHit.Add(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss") && !enemiesHit.Contains(collision) && false)
        {
            collision.GetComponent<EnemyStats>().TakeDamage(damage, player);
            enemiesHit.Add(collision);
        }

        if(!enemiesHit.Contains(collision))
        {
            enemiesHit.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(enemiesHit.Contains(collision))
        {
            enemiesHit.Remove(collision);
        }
    }

    private void OnEnable()
    {
        
    }



    private void OnDisable()
    {
        enemiesHit.Clear();
    }

}
