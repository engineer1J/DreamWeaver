using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTouchCheck : MonoBehaviour {

    public bool onTouch = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("Player") && onTouch)
        {
            //FGameManager.instance.hurted = true;
            onTouch = false;
        }
        onTouch = false;
    }

    

}
