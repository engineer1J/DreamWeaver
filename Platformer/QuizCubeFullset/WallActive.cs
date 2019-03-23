using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActive : MonoBehaviour {

    public GameObject[] wallChild;
    private readonly int MAX_CHILD = 4;


	// Use this for initialization
	void Start () {
        wallChild = new GameObject[MAX_CHILD];
        
        for(int i=0; i<MAX_CHILD; i++)
        {
            wallChild[i] = transform.GetChild(i).gameObject;
        }

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetActive(bool active)
    {
        if(active)
        {
           for(int i=0; i < MAX_CHILD; i++)
            {
                wallChild[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < MAX_CHILD; i++)
            {
                wallChild[i].SetActive(false);
            }
        }
    }

}
