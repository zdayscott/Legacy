using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability4Script : MonoBehaviour {

    public GameObject Ability4;

    public void OnClick()
    {
        //Attack4
        Debug.Log("Ability4");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Attack4
            Debug.Log("Ability4");
        }
    }
}
