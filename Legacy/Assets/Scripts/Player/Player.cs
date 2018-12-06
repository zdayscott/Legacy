using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    public TMPro.TMP_Text levelText;

    [Header("Experience and Leveling")]
    private int experience;
    private int level=1;
    public Slider experienceBar = null;
    public Text expText;

    [SerializeField]
    // Experience needed to get to next level
    private int[] expLevels;
    private int nextLevelEXP = 50;


    public Transform itemDropLoc;

    private void Awake()
    {
        if(healthbar == null)
        {
            //Debug.Log("Finding GO");
            healthbar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>(); 
        }


        if(experienceBar == null)
        {
            experienceBar = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<Slider>();
        }
    }

    // Use this for initialization
    void Start ()
    {
        if (healthbar == null)
        {
            healthbar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        }


        if (experienceBar == null)
        {
            experienceBar = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<Slider>();
        }

        equipmentManager = EquipmentManager.instance;
        inventory = Inventory.instance;

        health = maxHealth;

        healthbar.maxValue = maxHealth;
        healthbar.minValue = 0f;

        experienceBar.maxValue = nextLevelEXP;
        experienceBar.minValue = 0;
        experienceBar.value = experience;
        expText.text = experience + "/" + nextLevelEXP;
        healthText.text = health.ToString();
        levelText.text = level.ToString();

        ResetStats();
       equipmentManager.onEquiptCallback += UpdateStats;
    }
	
	// Update is called once per frame
	void Update ()
    {
        expText.text = experience + "/" + nextLevelEXP;
        healthText.text = health.ToString();
        levelText.text = level.ToString();
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
        if(EquipmentManager.instance.currentWeapon is LegacyWeaponSO)
        {
            GetComponent<LegacyLauncher>().SendWeapon((LegacyWeaponSO)EquipmentManager.instance.currentWeapon);
        }

        // Call next scene or next function in gameover sequence
        SceneManager.LoadScene(2);
    }

    public void ExpGain(int exp)
    {
        experience += exp;
        if(experience >= nextLevelEXP)
        {
            LevelUp();
        }
        experienceBar.value = experience;
    }

    void LevelUp()
    {
        experience -= nextLevelEXP;
        level++;
        float nxt = nextLevelEXP * (2f + ((float)level / 10f));
        Debug.Log(nxt);
        nextLevelEXP = (int)nxt;
        experienceBar.maxValue = nextLevelEXP;
        UpgradeBaseStats();
        UpdateStats();

        HealOnLvlUp();

        if (equipmentManager.currentWeapon is LegacyWeaponSO)
        {
            LegacyWeaponSO legacy = (LegacyWeaponSO)equipmentManager.currentWeapon;
            legacy.level++;
            legacy.damage += legacy.level;
        }
    }

    void UpgradeBaseStats()
    {

        switch(level % 4)
        {
            case 1:
                Debug.Log("Level UP!");
                maxHealth += 25;
                break;
            case 2:
                attackDamage_Base += 1 + level / 4;
                break;
            case 3:
                maxHealth += 10;
                break;
            case 0:
                movementSpeed_Base += .5f;
                break;
        }
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
            attackDamage_Current += equipmentManager.currentWeapon.damage;
        }
    }

    void HealOnLvlUp()
    {
        health = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = Mathf.Max(0, health);
    }
}
