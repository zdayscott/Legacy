using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayScript : MonoBehaviour {

    public void StartGame(int SceneIndex)
    {
        GameObject[] gos = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in gos)
        {
            if(obj.tag == "Player" || obj.tag == "UI" || obj.tag == "Game Manager")
            {
                Destroy(obj);
            }
        }
        SceneManager.LoadScene(SceneIndex);
    }

}
