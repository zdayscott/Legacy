using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewGame : MonoBehaviour {

    public void BeginGame(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
