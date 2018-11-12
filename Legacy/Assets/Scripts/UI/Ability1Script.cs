using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1Script : MonoBehaviour {

    public GameObject Ability1;

    public void OnClick()
    {
        //Attack1
        Debug.Log("Ability1");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Attack1
            Debug.Log("Ability1");
        }
    }
}
