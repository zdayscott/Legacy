using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


    public float speed = 5;
    public float damage = 15;
    private Rigidbody2D rb;
    public bool canShoot = false;
    public float timeAlive = 6.0f;
    //public Transform target;
    private Vector2 targetLocation;

    public GameObject fire;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(DestroyProjectile());
    }
	
    public void updateShoot()
    {
        canShoot = true;
    }

	// Update is called once per frame
	void Update ()
    {
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            collide.GetComponent<Player>().TakeDamage(15);
            Destroy(gameObject);
        }
        else if (collide.gameObject.tag != "Enemy" && collide.gameObject.tag == "Projectile")
        {
            GameObject smallFire = Instantiate(fire, gameObject.transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
