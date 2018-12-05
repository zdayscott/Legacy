using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOnLoadUI : MonoBehaviour {

    public static GameObject ui;

    private void Awake()
    {
        if (ui == null)
        {
            ui = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (ui != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
