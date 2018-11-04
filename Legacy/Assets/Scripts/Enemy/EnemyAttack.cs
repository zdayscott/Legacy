using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int damage = 5;

    void OnTriggerEnter2D(Collider2D PlayerHit)
    {
        if (PlayerHit.gameObject.tag == "Player")
        {
            PlayerHit.GetComponent<Player>().takeDamage(damage);
            Debug.Log("Enemy hit for damage");
        }
    }
}
