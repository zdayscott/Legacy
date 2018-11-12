using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2Script : MonoBehaviour {

    public GameObject Ability2;

    public void OnClick()
    {
        //Attack2
        Debug.Log("Ability2");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Attack2
            Debug.Log("Ability2");
        }
    }
}
