using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float maxHeath = 10;
    private float currentHealth;

    public int expDroped = 5;

    public GameObject Exit;

    public LootTable LT;
    public int lootChance = 33;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHeath;
        LT = this.GetComponent<LootTable>();
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

        if(this.gameObject.tag == "Boss")
        {
            Debug.Log("Spawning Exit!!!");
            Vector3 pos = this.transform.position;
            pos.z = -1;
            Quaternion rot = this.transform.rotation;
            rot.z = 0;
            Instantiate(Exit, pos, rot);
        }

        //Check if it does drop anything
        if(LT != null && Random.Range(0,100) <= lootChance)
        {
            Vector3 posL = this.transform.position;
            posL.z = -1;
            Quaternion rotL = this.transform.rotation;
            rotL.z = 0;
            Instantiate(LT.RollLoot(), posL, rotL);
        }

        Destroy(this.gameObject);
    }
}
