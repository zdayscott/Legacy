﻿using System.Collections;
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
        player.transform.position = resetPoint;
        GameObject gm = GameObject.FindGameObjectWithTag("Game Manager");
        gm.GetComponent<GM>().currentFloor++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
