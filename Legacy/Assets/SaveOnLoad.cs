using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveOnLoad : MonoBehaviour {

    public static GameObject player;

    private void Awake()
    {
        if (player == null)
        {
            player = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (player != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            Destroy(this.gameObject);
        }
    }
}
