using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    public float speed = 5f;
    public Transform target;
    Rigidbody2D rb;

    public float closeEnough = .25f;
    public float range = 7f;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();	
        if(target == null)
        {
           target = GameObject.FindGameObjectWithTag("Player").transform;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distanceToTarget = CalculateDistance(target, this.transform);
        if (distanceToTarget <= closeEnough)
        {
            Attack();   //------------------------TODO----------------------------------
        }
        else if(distanceToTarget <= range)
        {
            SeekTarget();
        }
	    	
	}

    float CalculateDistance(Transform a, Transform b)
    {
        return Mathf.Pow((Mathf.Pow(a.position.x - b.position.x, 2) + Mathf.Pow(a.position.y - b.position.y, 2)), .5f);
    }

    void Attack()
    {

    }
    
    void SeekTarget()
    {
        Vector2 moveDir = new Vector2(target.position.x - this.transform.position.x, target.position.y - this.transform.position.y).normalized;

        rb.transform.Translate(moveDir * speed * Time.deltaTime);
    }
}
