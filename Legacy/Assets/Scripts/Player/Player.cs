using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float health;

	// Use this for initialization
	void Start ()
    {
        health = 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
     
	}

    public void takeDamage(int damage)
    {
        Debug.Log("player took damage");
        health = health - damage;
    }
}
