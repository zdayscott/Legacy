using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public int damage;
    public float timeAlive;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FireDuration());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator FireDuration()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            collide.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collide.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
