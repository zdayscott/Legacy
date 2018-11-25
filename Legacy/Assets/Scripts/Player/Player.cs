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

    [Header("Experience and Leveling")]
    private int experience;
    private int level;
    public Slider experienceBar = null;
    public Text expText;

    [SerializeField]
    // Experience needed to get to next level
    private int[] expLevels;


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

        if(experienceBar == null)
        {
            experienceBar = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<Slider>();
        }
        experienceBar.maxValue = expLevels[level];
        experienceBar.minValue = 0;
        experienceBar.value = experience;
        expText.text = experience + "/" + expLevels[level];
    }
	
	// Update is called once per frame
	void Update ()
    {
        expText.text = experience + "/" + expLevels[level];
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
        health = health - damage;
        healthbar.value = Mathf.Max(0,health);
    }

    public void ExpGain(int exp)
    {
        experience += exp;
        if(experience >= expLevels[level])
        {
            experience -= expLevels[level];
            level++;
            experienceBar.maxValue = expLevels[level];
        }
        experienceBar.value = experience;
    }
}
