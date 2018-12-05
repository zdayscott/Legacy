using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public void DestroyAll()
    {
        Debug.Log("Start!!!");
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            Debug.Log("Kill call!!!");
            Destroy(this.gameObject);
        }
    }
}
