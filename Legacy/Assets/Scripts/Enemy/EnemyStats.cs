using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float maxHeath = 10;
    private float currentHealth;

    public int expDroped = 5;


	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHeath;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount, GameObject attacker)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ExpGain(expDroped);
        Destroy(this.gameObject);
    }
}
