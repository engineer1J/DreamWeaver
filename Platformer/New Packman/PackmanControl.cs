using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackmanControl : MonoBehaviour {

    private StartDetect sd;
    private PackmanTranslate pt;
	// Use this for initialization
	void Start () {
        sd = transform.Find("StartDetection").GetComponent<StartDetect>();
        pt = transform.Find("Enemy").GetComponent<PackmanTranslate>();
	}
	
	// Update is called once per frame
	void Update () {
		if(sd.isStart)
        {
            StartGame();
            sd.isStart = false;
        }
	}

    public void StartGame()
    {
        pt.Move();
    }

    public void GameOver()
    {
        pt.Initialization();
    }
}
