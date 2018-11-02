using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;

    public int speed = 5;

    public GameObject Attack;

    Vector2 attackingDirection = new Vector2(1,0);
	// Use this for initialization
	void Start () {

        rb = this.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 move;
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        move = new Vector2(horz, vert).normalized;

        rb.transform.Translate(move * speed * Time.deltaTime);



       if (move.x != 0 || move.y != 0)
        {
            attackingDirection = move;
        }

        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Firing");

            Attack.transform.localPosition = attackingDirection * .7f;
            Attack.SetActive(true);
            

        }


        
		
	}
}
