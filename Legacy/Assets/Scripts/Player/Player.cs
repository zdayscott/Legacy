using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [Header("Health")]
    public int maxHealth = 100;
    private int health;
    public Slider healthbar = null;

    private Inventory inventory;

    [Header("Stats")]
    public float defense = 1f;
    public float attackDamage;
    public float attackSpeed;
    public float movementSpeed;


	// Use this for initialization
	void Start ()
    {
        health = maxHealth;

        if(healthbar == null)
        {
            //Debug.Log("Finding GO");
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
        if (health == 0)
        {
        SceneManager.LoadScene(3);
        }
    } 

    public void TakeDamage(int damage)
    {
        Debug.Log("player took damage");
        health = health - damage;
        healthbar.value = Mathf.Max(0,health);
    }
}
