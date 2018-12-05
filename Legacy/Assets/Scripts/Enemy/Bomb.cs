using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    // GameObject used for fire sprite after bomb explodes
    public GameObject fire;
    private GameObject[] fireEmbers = new GameObject[8];

    public float spread;
    public float timer;
    public float radius = 1.5f;
    public float power = 5.0f;
    public int damage = 30;
    private bool exploded;

    // Colors the bomb will alternate between
    public Color StartColor = Color.black;
    public Color endColor = Color.red;

    private SpriteRenderer bombSprite;
    public Material bombMaterial;

	// Use this for initialization
	void Start ()
    {
        bombSprite = GetComponent<SpriteRenderer>();
        exploded = false;
        StartCoroutine(ChangeColor());
        Invoke("Explode", timer);
	}
	
	// Update is called once per frame
	void Update ()
    {
       
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
        //Destroy(gameObject, 0.13f);
        Collider2D[] colliders;

        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        // Create a circle collider around the bomb
        // that damages any nearby enemmies and player
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.gameObject.GetComponent<Rigidbody2D>();

            // Calculate the current direction the player is moving
            // Push the player/enemy in the opposite direction from which they moving
            Vector2 direction = new Vector2(gameObject.transform.position.x - rb.transform.position.x, gameObject.transform.position.y - rb.transform.position.y);
            rb.AddForce(- direction * power, ForceMode2D.Impulse);

            if (hit.gameObject.tag == "Player")
            {
                hit.GetComponent<Player>().TakeDamage(damage);
            }

            if (hit.gameObject.tag == "Enemy")
            {
                hit.GetComponent<EnemyStats>().TakeDamage(damage, fire);
            }
        }

        // Once the bomb timer runs out, call function
        // to spread fire in random directions
        StartCoroutine(SpreadFire());
        bombSprite.enabled = false;
        Destroy(gameObject, .16f);
    }

    private IEnumerator SpreadFire()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector3 direction = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
            Instantiate(fire, transform.position + direction, transform.rotation);
            yield return new WaitForSeconds(.02f);
        }
    }
}
