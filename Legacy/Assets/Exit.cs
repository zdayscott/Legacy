using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
    Vector3 resetPoint = new Vector3(10, 5, 3);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            NextLevel(collision.gameObject);
        }
    }

    void NextLevel(GameObject player)
    {
        GameObject gameMan = GameObject.FindGameObjectWithTag("Game Manager");
        DontDestroyOnLoad(gameMan);
        player.transform.position = resetPoint;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
