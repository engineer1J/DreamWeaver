using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePackman : MonoBehaviour {

    GameObject boss;
    Vector3 upVec;
    public float upY = 10f;
    public bool isTouched = false;
    public bool isExit = true;
    public bool hit = false;

	// Use this for initialization
	void Start () {
        boss = GameObject.FindWithTag("Boss");
        upVec = new Vector3(0, upY, 0);
    }
	
	// Update is called once per frame
	void Update () {

        upVec.Set(0, upY, 0);
        transform.position = boss.transform.position + upVec;

	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Flag") && isExit)
        {
            isTouched = true;
            isExit = false;
            Debug.Log("enter");

        }
        if (col.CompareTag("Player") && !hit)
        {
            hit = true;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Flag"))
        {
            isExit = true;
            Debug.Log("exit");
        }
        if (col.CompareTag("Player"))
        {
            hit = false;
        }



    }

    public void SetBool(bool isTouch)
    {
        isTouched = isTouch;
    }
    public bool GetBool()
    {
        return isTouched;
    }
    public bool IsHit()
    {
        return hit;
    }

}
