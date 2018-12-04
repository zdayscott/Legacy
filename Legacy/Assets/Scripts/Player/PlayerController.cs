using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

    public int speed = 5;
    Player playerStats;

    [Header("Attack Variables")]
    //The GameObj that containes the collider and attack sprite
    public GameObject attackObj;
    public GameObject ninjaStar;
    Vector2 attackingDirection = new Vector2(1,0);

    //Time the attack collider will be active
    public float attackTime = .25f;
    private float attackTimeCurrent;

    //Time between attacks
    public float rechargeTime = .4f;
    private float rechargeTimeCurrent;

    // Keep track of time until player can throw another projectile
    private float nextStarReady = 0;

	// Use this for initialization
	void Start () {

        rb = this.GetComponent<Rigidbody2D>();
        attackTimeCurrent = attackTime;
        rechargeTimeCurrent = rechargeTime;

        playerStats = gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();

        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
        if (Input.GetButton("Fire2"))
        {
            ThrowProjectile();
        }
        UpdateCooldowns();
    }


    void MovePlayer()
    {
        Vector2 move;
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        move = new Vector2(horz, vert).normalized;

        rb.transform.Translate(move * playerStats.movementSpeed_Current * Time.deltaTime);
    }

    void Attack()
    {
        Vector2 mousePos = Input.mousePosition;
        Debug.Log("Mouse pos: " + mousePos);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("Mouse pos Screen: " + mousePos);

        attackingDirection = new Vector2(mousePos.x - this.transform.position.x, mousePos.y - this.transform.position.y).normalized;

        Debug.Log(attackingDirection);

        if (rechargeTimeCurrent <= 0)
        {
            attackObj.transform.localPosition = attackingDirection * .7f;
            attackObj.SetActive(true);
            attackObj.GetComponent<Attack>().damage = (int)playerStats.attackDamage_Current;
            attackTimeCurrent = attackTime;
            rechargeTimeCurrent = rechargeTime;
        }
    }

    void ThrowProjectile()
    {
        // calculate direction the player is facing
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Calculate which direction the mouse is moving
        Vector3 attackDir = new Vector3(mousePos.x - this.transform.position.x, mousePos.y - this.transform.position.y, 0).normalized;
        Vector3 offset = new Vector3(attackDir.x * .3f, attackDir.y * .3f, 0); // offset needed to avoid collision with player

        if (nextStarReady <= 0)
        {
            // Instantiate the ninja star prefab and throw in the direction mouse is facing
            GameObject star = Instantiate(ninjaStar, transform.position + attackDir + offset, gameObject.transform.rotation) as GameObject;
            Rigidbody2D rbStar = star.GetComponent<Rigidbody2D>();
            rbStar.AddForce(attackDir * speed, ForceMode2D.Impulse);

            // Set string to player to help with detecting collisions
            star.GetComponent<Projectile>().ShotFiredBy("Player");
            nextStarReady = rechargeTime;
        }
    }

    void UpdateCooldowns()
    {
        rechargeTimeCurrent -= Time.deltaTime;
        nextStarReady -= Time.deltaTime;
        if(attackTimeCurrent > 0)
        {
            attackTimeCurrent -= Time.deltaTime;
        }
        else
        {
            //attackObj.AddComponent<Attack>().AttackEnded();
            attackObj.SetActive(false);
        }
    }
}
