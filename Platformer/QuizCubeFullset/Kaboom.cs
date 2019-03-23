using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaboom : MonoBehaviour {


    GameObject explosion_clone;
    GameObject warning_clone;

    private Vector3 downVec;
    private Vector3 upVec;


    // Use this for initialization
    void Start () {
        downVec = new Vector3(0f, -2f, 0f);
        upVec = new Vector3(0f, 0.1f, 0f);
	}
	
	// Update is called once per frame


    public void Explode(GameObject explosion,float explosionTime)
    {
            explosion_clone = Instantiate(explosion, transform.position + downVec , Quaternion.identity);
            Destroy(explosion_clone, explosionTime);
    }

    public void WarningEffect(GameObject warningEffect, float warningEffectTime)
    {

        warning_clone = Instantiate(warningEffect, transform.position + upVec, Quaternion.identity);
            Destroy(warning_clone, warningEffectTime);



    }

}
