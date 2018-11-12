using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability5Script : MonoBehaviour {

    public GameObject Ability5;

    public void OnClick()
    {
        //Attack5
        Debug.Log("Ability5");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Attack5
            Debug.Log("Ability5");
        }
    }
}
