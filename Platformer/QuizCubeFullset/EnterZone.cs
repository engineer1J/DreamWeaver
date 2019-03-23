using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterZone : MonoBehaviour {

    public bool isEnter = false; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    public void SetIsEnter(bool isEnter)
    {
        this.isEnter = isEnter;
    }

    public bool GetIsEnter()
    {
        return isEnter;
    }
}
