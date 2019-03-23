using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCubeManager : MonoBehaviour {

    public SwitchDirection[] switchCubeChild;
    private readonly int MAX_CHILD = 9;
    private readonly int CHANGE_ENTER_MODE = 0;
    private readonly int CHANGE_OUT_MODE = 1;
    public float cameraDistance = 0f;
    public float cameraHeight = 0f;


    public SwitchDirection.Enter_Out_DIRECTION enterDir_LOCAL;
    public SwitchDirection.Enter_Out_DIRECTION outDir_GLOBAL;


    // Use this for initialization
    void Start () {
        switchCubeChild = new SwitchDirection[9];
        
        for(int i=0; i<9; i++)
        {
            switchCubeChild[i] = transform.GetChild(i).GetComponent<SwitchDirection>();
        }

	}
	
	// Update is called once per frame
	void Update () {

        changeDir(enterDir_LOCAL, CHANGE_ENTER_MODE);
        changeDir(outDir_GLOBAL, CHANGE_OUT_MODE);

        for(int i=0; i<MAX_CHILD; i++)
        {
            switchCubeChild[i].SetCameraStatus(cameraDistance, cameraHeight);
        }
    }
    

    void changeDir(SwitchDirection.Enter_Out_DIRECTION next, int mode)
    {
        if (mode == CHANGE_ENTER_MODE)
        {
            for (int i = 0; i < MAX_CHILD; i++)
            {
                switchCubeChild[i].enterDirection = enterDir_LOCAL;
            }
        }
        else if(mode == CHANGE_OUT_MODE)
        {
            for (int i = 0; i < MAX_CHILD; i++)
            {
                switchCubeChild[i].outDirection = outDir_GLOBAL;
            }
        }
    }
}
