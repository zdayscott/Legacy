using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    // GameObject used for fire sprite after bomb explodes
    public GameObject fire;
    public float timer;
    public float radius = 5.0f;
    public float power = 5.0f;
    public int damage = 30;

    // Colors the bomb will alternate between
    public Color StartColor = Color.black;
    public Color endColor = Color.red;


    private SpriteRenderer bombSprite;
    public Material bombMaterial;

	// Use this for initialization
	void Start ()
    {
        bombSprite = GetComponent<SpriteRenderer>();

        StartCoroutine(Detonate());
        StartCoroutine(ChangeColor());
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(timer);
        Explode();
        Destroy(gameObject);
    }

    IEnumerator ChangeColor()
    { 
        // Alternate bewteen the color black and red every 1 second
        float timeElapsed = 0f;
        float delay = 1f;

        while (timeElapsed < timer)
        {
            timeElapsed += Time.deltaTime;
 
            bombSprite.color = Color.Lerp(endColor, StartColor, Mathf.PingPong(Time.time, timer / timeElapsed));
            yield return null;
        }
    }

    void Explode()
    {
        Collider2D[] colliders;

        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in colliders)
        {
            if (hit.gameObject.tag == "Player")
            {

                Rigidbody2D rb = hit.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.up * power, ForceMode2D.Impulse);
                hit.GetComponent<Player>().TakeDamage(damage);
            }
        }
    }
}
