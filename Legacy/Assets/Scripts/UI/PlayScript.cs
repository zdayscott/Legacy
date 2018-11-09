using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayScript : MonoBehaviour {

    public void StartGame(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

}
