using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door : MonoBehaviour {
    public GameObject loading;
    bool isLoad = true;

    [SerializeField]
    Image progressBar;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
    void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isLoad) {
            Debug.Log("enter door");
            startRoomEscape();
            loading.SetActive(true);
            isLoad = false;
        }
    }

    void startRoomEscape() {
        gameObject.AddComponent<LoadingScene>();
        gameObject.GetComponent<LoadingScene>().ChangeScene(progressBar, 2);
    }
}
