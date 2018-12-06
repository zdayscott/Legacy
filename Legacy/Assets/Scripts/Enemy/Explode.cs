using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public int damage;
    public float timeAlive;

    private SpriteRenderer fireSprite;

    // Colors the fire will alternate between
    public Color StartColor = Color.red;
    public Color endColor = Color.yellow;

    // Use this for initialization
    void Start ()
    {
        fireSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(FireDuration());
        StartCoroutine(ChangeColor());
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator FireDuration()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }

    IEnumerator ChangeColor()
    {
        // Alternate bewteen the color black and red every 1 second
        float timeElapsed = 0f;
        float delay = 1f;

        while (timeElapsed < timeAlive)
        {
            timeElapsed += Time.deltaTime;

            fireSprite.color = Color.Lerp(endColor, StartColor, Mathf.PingPong(Time.time, timeAlive / timeElapsed));
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            collide.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collide.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
