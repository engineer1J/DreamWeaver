using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platformer_Manager : Singleton<Platformer_Manager> {
    int coinScore = 0;
    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore () {
        coinScore++;
        scoreText.text = "Score : " + coinScore.ToString();
    }
}
