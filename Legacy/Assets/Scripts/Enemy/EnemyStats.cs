using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float maxHeath = 10;
    private float currentHealth;


	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHeath;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
