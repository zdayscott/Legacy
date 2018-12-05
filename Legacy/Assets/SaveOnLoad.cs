using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
