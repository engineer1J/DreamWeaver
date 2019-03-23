using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour {

    public QuizManagement parent;

	// Use this for initialization
	void Start () {
        parent = GameObject.Find("QuizCubeManager").GetComponent<QuizManagement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            parent.collisionCheck = true;  //AnswerButton의 check여부를 매니저에게 알려주기
        }
    }

}
