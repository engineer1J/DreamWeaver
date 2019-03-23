using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClock : MonoBehaviour {
    public float rotationSpeed = 10.0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
    }
}
