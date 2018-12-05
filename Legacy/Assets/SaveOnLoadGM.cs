using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOnLoadGM : MonoBehaviour {

    public static GameObject gm;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (gm != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
