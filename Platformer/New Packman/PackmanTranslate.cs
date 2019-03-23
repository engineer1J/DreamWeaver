using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackmanTranslate : MonoBehaviour {

    private bool isTouchFlag;
    private ChasePackman chasePackman;
    public int count = 0;

    private Vector3 left;
    private Vector3 right;
    private Vector3 firstPos;
    private Vector3 firstRot;




    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        chasePackman = transform.Find("CollisionBox").GetComponent<ChasePackman>();


        left = new Vector3(0, -90, 0);
        right = new Vector3(0, 90, 0);

        firstPos = transform.position;
        firstRot = transform.rotation.eulerAngles;


    }

    public void Initialization()
    {
        count = 0;
        transform.position = firstPos;
        transform.rotation = Quaternion.Euler(firstRot);
        iTween.Stop(gameObject);
        
    }
	
	// Update is called once per frame
	void Update () {
        isTouchFlag = chasePackman.GetBool();
        if (isTouchFlag)
        {
            chasePackman.SetBool(false);
            RotatePackman();
        }
    }
    
    void RotatePackman()
    {
        switch(count)
        {
            case 0:
                count++;
                RotateRight();
                break;
            case 1:
                count++;
                RotateLeft();
                break;
            case 2:
                count++;
                RotateLeft();
                break;
        }
    }

    public void Move()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PackPath"),
        "easetype", iTween.EaseType.linear, "speed", 10f, "oncomplete" , "Initialization"));
    }

    void RotateLeft()
    {
        Debug.Log("RotateLeft");
        iTween.RotateTo(gameObject,
        iTween.Hash(
         "rotation", transform.rotation.eulerAngles + left,
            "time", 2f,
            "easeType", iTween.EaseType.linear));
    }
    void RotateRight()
    {
        Debug.Log("RotateRight");
        iTween.RotateTo(gameObject,
        iTween.Hash(
         "rotation", transform.rotation.eulerAngles + right,
            "time", 2f,
            "easeType", iTween.EaseType.linear));
    }
}
