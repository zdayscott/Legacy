using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float health; 
    

	// Use this for initialization
	void Start ()
    {
        gameObject.tag = "Player";
    }
	
	// Update is called once per frame
	void Update ()
    {
        basicMovement();
	}

    void basicMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);
        }
    }
}
