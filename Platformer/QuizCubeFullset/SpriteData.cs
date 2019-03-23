using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteData : MonoBehaviour {

    
    public Texture[] cubeMaterial;
    public MeshRenderer render;


	// Use this for initialization
	void Start () {

        render = gameObject.GetComponent<MeshRenderer>();
        //render.material.SetTexture("_MainTex", cubeMaterial[1]);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetImage(int num)
    {

        render.material.SetTexture("_MainTex", cubeMaterial[num]);

    }

}
