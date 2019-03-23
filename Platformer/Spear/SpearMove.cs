using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMove : MonoBehaviour {

    Rigidbody rigidBody;

    private float upSpeed = 40f;
    private float downSpeed = 4f;
    private float timer = 0;
    public float upTime = 1.04f;
    Vector3 initPosition;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        initPosition = rigidBody.position;

	}
	
	// Update is called once per frame
	void Update () {
        if(timer <= 1f)
        {
            timer += Time.deltaTime;
           // Debug.Log(timer);
        }
        else if (timer <= upTime)
        {
            rigidBody.MovePosition(rigidBody.position + Vector3.up * Time.deltaTime * upSpeed);
            timer += Time.deltaTime;
        }
        else if(timer <= 2)
        {
            timer += Time.deltaTime;
        }
        else
        {
            rigidBody.MovePosition(rigidBody.position + Vector3.down * Time.deltaTime * downSpeed);
            timer += Time.deltaTime;
        }


        if (rigidBody.position.y < initPosition.y)
        {
            timer = 0;
            rigidBody.position = initPosition;
        }


    }


}
