using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField]
    public float maxHealth=100f;
    private float health;
    public Slider healthbar;
	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.minValue = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void FixedUpdate()
    {
        healthbar.value = health;
    }

    public void takeDamage(int damage)
    {
        Debug.Log("player took damage");
        health = health - damage;
    }
}
