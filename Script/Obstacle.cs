using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Obstacle"))
        {
            FGameManager.instance.hurted = true;
        }

    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Boss"))
        {
            FGameManager.instance.hurted = true;
            FGameManager.instance.hurted = true;
        }
    }


}
