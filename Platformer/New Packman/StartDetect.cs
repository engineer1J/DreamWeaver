using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDetect : MonoBehaviour {


    public bool isStart = false;
    public CameraControl main;
    private Camera mainCamera;
	// Use this for initialization
	void Start () {
        main = Camera.main.GetComponent<CameraControl>();
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isStart = true;
            main.CameraSet(16, 6f);
            main.sound[2].loop = true;
            main.sound[2].Play();
            main.sound[0].Stop();
            mainCamera.farClipPlane = 300.0f;
            
        }
    }
}
