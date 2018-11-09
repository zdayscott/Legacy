using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

    public int speed = 5;

    [Header("Attack Variables")]
    //The GameObj that containes the collider and attack sprite
    public GameObject attackObj;
    Vector2 attackingDirection = new Vector2(1,0);

    //Time the attack collider will be active
    public float attackTime = .25f;
    private float attackTimeCurrent;

    //Time between attacks
    public float rechargeTime = .4f;
    private float rechargeTimeCurrent;



	// Use this for initialization
	void Start () {

        rb = this.GetComponent<Rigidbody2D>();
        attackTimeCurrent = attackTime;
        rechargeTimeCurrent = rechargeTime;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();

        if (Input.GetButton("Fire1"))
        {
            Attack();
        }

        UpdateCooldowns();
    }


    void MovePlayer()
    {
        Vector2 move;
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        move = new Vector2(horz, vert).normalized;

        rb.transform.Translate(move * speed * Time.deltaTime);

        /*if (move.x != 0 || move.y != 0)
         {
             attackingDirection = move;
         }*/

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
            attackTimeCurrent = attackTime;
            rechargeTimeCurrent = rechargeTime;
            //Debug.Log("Firing");
        }
    }

    void UpdateCooldowns()
    {
        rechargeTimeCurrent -= Time.deltaTime;
        if(attackTimeCurrent > 0)
        {
            attackTimeCurrent -= Time.deltaTime;
        }
        else
        {
            attackObj.SetActive(false);

        }
    }
}
