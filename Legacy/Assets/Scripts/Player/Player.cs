using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField]
    public float maxHealth=100f;
    private float health;
    public Slider healthbar = null;
	// Use this for initialization
	void Start ()
    {
        health = maxHealth;

        if(healthbar == null)
        {
            Debug.Log("Finding GO");
            healthbar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>(); 
        }
        healthbar.maxValue = maxHealth;
        healthbar.minValue = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void FixedUpdate()
    {

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("player took damage");
        health = health - damage;
        healthbar.value = Mathf.Max(0,health);
    }
}
