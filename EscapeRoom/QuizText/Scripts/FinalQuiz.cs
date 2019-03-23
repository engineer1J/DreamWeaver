using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalQuiz : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //잠금화면에는 shutdown버튼을 안만들어놓음
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            R_GameManager.instance.quizPicutreUI.gameObject.SetActive(false);
            R_GameManager.instance.quizPicutre.gameObject.SetActive(true);
            R_GameManager.instance.PlayerMovement(true);
            R_GameManager.instance.SetPlayerRotation(true);
        }
    }
}
