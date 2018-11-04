using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramover : MonoBehaviour {

    public Transform target;
    public float smoothingSpeed = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        Vector3 smoothedDesiredLoctation = Vector3.Lerp(this.transform.position, desiredPosition, smoothingSpeed);

        this.transform.position = smoothedDesiredLoctation;



		
	}
}
