using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {

    public Vector3 spawnPoint;
    public int savePointCount = 0;
    // Use this for initialization
    void Start () {
        spawnPoint = GetComponent<Transform>().position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider c) //occur when player get in
    {
        if (c.gameObject.CompareTag("SavePoint"))
        {
            FGameManager.instance.savePointBgm.Play();
            spawnPoint = c.GetComponent<Transform>().position;  //renew spawnPoint
            c.gameObject.SetActive(false);
            savePointCount++;
        }

    }

    public int GetSaveCount()
    {
        return savePointCount;
    }
}
