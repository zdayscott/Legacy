using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

    public GameObject dashAnimate;
    public float dashCoolDown = 5f;
    private float dashRechargeRate = 0f;
    public float dashPower = 10f;

    public int speed = 5;
    private Vector3 lastPosition;

    Player playerStats;

    [Header("Attack Variables")]
    //The GameObj that containes the collider and attack sprite
    public GameObject attackObj;

    // Gameobject used for players weapons
    public GameObject ninjaStar;
    public GameObject bomb;
    public float nextBombReady;
    public float bombCooldown;
    public float bombCount;

    public int numOfStars;
    public Image starRecharge;
    public Image dashRecharge;


    Vector2 attackingDirection = new Vector2(1,0);

    //Time the attack collider will be active
    public float attackTime = .25f;
    private float attackTimeCurrent;

    //Time between attacks
    public float rechargeTime = .4f;
    public float ninjaStarCD = 2f;
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
        Vector2 startPoint = transform.position + lastPosition * 2f;
        Debug.DrawRay(startPoint, lastPosition * dashPower, Color.yellow, .1f, true);
        MovePlayer();

        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
        if (Input.GetButton("Fire2") && numOfStars > 0)
        {
            ThrowProjectile();
        }
        if (Input.GetButton("Bomb"))
        {
            ThrowBomb();
        }

        UpdateCooldowns();
    }


    void MovePlayer()
    {
        Vector2 move;
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        move = new Vector2(horz, vert).normalized;

        Vector2 startPoint = transform.position + lastPosition * 2f;
        if (Input.GetButton("Jump") && CanDash(startPoint, move , dashPower))
        {
            if (dashRechargeRate <= 0)
            {
                Dash();
            }
        }
        lastPosition = move;
        rb.transform.Translate(move * playerStats.movementSpeed_Current * Time.deltaTime);
    }

    void Attack()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        attackingDirection = new Vector2(mousePos.x - this.transform.position.x, mousePos.y - this.transform.position.y).normalized;

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
            GameObject star = Instantiate(ninjaStar, transform.position + attackDir + offset, transform.rotation) as GameObject;
            Rigidbody2D rbStar = star.GetComponent<Rigidbody2D>();
            rbStar.AddForce(attackDir * speed, ForceMode2D.Impulse);
            // Set string to player to help with detecting collisions
            star.GetComponent<Projectile>().ShotFiredBy("Player");
            nextStarReady = ninjaStarCD;
            numOfStars -= 1;
        }
    }

    void Dash()
    {
        dashRechargeRate = dashCoolDown;
        //rb.AddForce(lastPosition * dashPower, ForceMode2D.Impulse);
        dashAnimate.SetActive(true);
        transform.position += lastPosition * dashPower;
        StartCoroutine(Pause(0.3f));
    }

    IEnumerator Pause(float delay)
    {
        yield return new WaitForSeconds(delay);
        dashAnimate.SetActive(false);
    }

    private bool CanDash(Vector3 start, Vector3 dir, float distance)
    {
        return Physics2D.Raycast(start , dir, distance).collider == null;

    }

    void ThrowBomb()
    {
        // calculate direction the player is facing
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Calculate which direction the mouse is moving
        Vector3 attackDir = new Vector3(mousePos.x - this.transform.position.x, mousePos.y - this.transform.position.y, 0).normalized;
        Vector3 offset = new Vector3(attackDir.x * .3f, attackDir.y * .3f, 0); // offset needed to avoid collision with player

        if (nextBombReady <= 0 && bombCount > 0)
        {
            // Instantiate the ninja star prefab and throw in the direction mouse is facing
            GameObject spareBomb = Instantiate(bomb, transform.position + attackDir + offset, transform.rotation) as GameObject;
            Rigidbody2D rbStar = spareBomb.GetComponent<Rigidbody2D>();
    
            rbStar.transform.Translate(transform.position + attackDir + offset);
            rbStar.AddForce(attackDir * speed, ForceMode2D.Impulse);
            // Set string to player to help with detecting collisions
            //star.GetComponent<Projectile>().ShotFiredBy("Player");
            nextBombReady = bombCooldown;
            bombCount -= 1;
        }
    }


    void DrinkPotion()
    {

    }

    void UpdateCooldowns()
    {
        rechargeTimeCurrent -= Time.deltaTime;
        nextStarReady -= Time.deltaTime;
        dashRechargeRate -= Time.deltaTime;
        nextBombReady -= Time.deltaTime;

        starRecharge.fillAmount = 1 - nextStarReady / 2;
        dashRecharge.fillAmount = 1 - dashRechargeRate / 2;

        if (attackTimeCurrent > 0)
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
