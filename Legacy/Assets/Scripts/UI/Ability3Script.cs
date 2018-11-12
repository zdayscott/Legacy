using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3Script : MonoBehaviour {

    public GameObject Ability3;

    public void OnClick()
    {
        //Attack3
        Debug.Log("Ability3");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Attack3
            Debug.Log("Ability3");
        }
    }
}
