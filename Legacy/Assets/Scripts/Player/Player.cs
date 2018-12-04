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
    private EquipmentManager equipmentManager;

    [Header("Stats")]
    public float defense_Base = 1f;
    public float attackDamage_Base = 2f;
    public float attackSpeed_Base = 1f;
    public float movementSpeed_Base = 10f;

    public float defense_Current;
    public float attackDamage_Current;
    public float attackSpeed_Current;
    public float movementSpeed_Current;

    public Text healthText;

    [Header("Experience and Leveling")]
    private int experience;
    private int level;
    public Slider experienceBar = null;
    public Text expText;

    [SerializeField]
    // Experience needed to get to next level
    private int[] expLevels;


    public Transform itemDropLoc;


	// Use this for initialization
	void Start ()
    {
        equipmentManager = EquipmentManager.instance;
        inventory = Inventory.instance;

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
        healthText.text = health.ToString();

        ResetStats();
       equipmentManager.onEquiptCallback += UpdateStats;
    }
	
	// Update is called once per frame
	void Update ()
    {
        expText.text = experience + "/" + expLevels[level];
        healthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health = health - damage/(int)defense_Current;
        healthbar.value = Mathf.Max(0,health);
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Do die stuff (eg. clear inventory, delete save send weapon to server)
        // Call next scene or next function in gameover sequence
        SceneManager.LoadScene(3);
    }

    public void ExpGain(int exp)
    {
        experience += exp;
        if(experience >= expLevels[level])
        {

        }
        experienceBar.value = experience;
    }

    void LevelUp()
    {
            experience -= expLevels[level];
            level++;
            experienceBar.maxValue = expLevels[level];
    }

    void ResetStats()
    {
        defense_Current = defense_Base;
        attackDamage_Current = attackDamage_Base;
        movementSpeed_Current = movementSpeed_Base;
    }

    void UpdateStats()
    {

        ResetStats();

        for(int i = 0; i < equipmentManager.currentEquiptment.Length; i++)
        {
            if(equipmentManager.currentEquiptment[i] != null)
            {
                defense_Current += equipmentManager.currentEquiptment[i].defenseMod;
                movementSpeed_Current += equipmentManager.currentEquiptment[i].movementMod;
            }
        }

        if(equipmentManager.currentWeapon != null)
        {
            Debug.Log("Updating Weapon Stats!!!");
            attackDamage_Current += equipmentManager.currentWeapon.damage;
        }
    }
}
