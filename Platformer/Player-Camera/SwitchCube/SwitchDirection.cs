using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDirection : MonoBehaviour {

    Camera mainCamera;
    Vector3 enterVector;
    Vector3 outVector;
    RaycastHit hit;
    public GameObject player;
    int PlayerMask;
    Transform player_transform;
    public Rigidbody attachedSphereRb;
    public float cameraDistance;
    public float cameraHeight;
    private CameraControl mainCameraControl;

    public enum Enter_Out_DIRECTION
    {
        FRONT,
        LEFT,
        RIGHT,
        BACK,
    }

    public Enter_Out_DIRECTION enterDirection;
    public Enter_Out_DIRECTION outDirection;
    public float distance = 4.0f;
    Quaternion cur_rotation;
    Vector3 rotationTemp;
    

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        mainCamera = Camera.main;
        enterVector = transform.position;
        outVector = transform.position;
        PlayerMask = LayerMask.GetMask("Player");
        cur_rotation = player.transform.rotation;
        player_transform = player.transform;
        rotationTemp = Vector3.zero;
        attachedSphereRb = GameObject.FindWithTag("AttachedSphere").GetComponent<Rigidbody>();
        mainCameraControl = mainCamera.GetComponent<CameraControl>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, enterVector, Color.red);

    }

    public void SetCamera()
    {
        mainCameraControl.CameraSet(cameraDistance, cameraHeight);
    }

    public void SetCameraStatus(float distance, float height)
    {
        cameraDistance = distance;
        cameraHeight = height;
    }


    void OnTriggerEnter(Collider col)
    {
       

        if (col.gameObject.tag == "Player")
        {
            
            GameObject player = col.gameObject;

            switch (enterDirection)
            {
                case Enter_Out_DIRECTION.BACK:
                    enterVector = -transform.forward;
                    break;
                case Enter_Out_DIRECTION.FRONT:
                    enterVector = transform.forward;
                    break;
                case Enter_Out_DIRECTION.LEFT:
                    enterVector = -transform.right;
                    break;
                case Enter_Out_DIRECTION.RIGHT:
                    enterVector = transform.right;
                    break;
            }
            switch (outDirection)
            {
                case Enter_Out_DIRECTION.BACK:
                    outVector = -transform.forward;
                    break;
                case Enter_Out_DIRECTION.FRONT:
                    outVector = transform.forward;
                    break;
                case Enter_Out_DIRECTION.LEFT:
                    outVector = -transform.right;
                    break;
                case Enter_Out_DIRECTION.RIGHT:
                    outVector = transform.right;
                    break;
            }

            if(Physics.Raycast(transform.position, enterVector, out hit, 10, PlayerMask))
            {
                switch(outDirection)
                {
                    case Enter_Out_DIRECTION.LEFT:
                        mainCamera.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.RIGHT;
                        mainCamera.GetComponent<CameraControl>().cameraDistance = distance;
                        StartCoroutine(wait2Sec());
                        break;
                    case Enter_Out_DIRECTION.RIGHT:
                        mainCamera.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.LEFT;
                        mainCamera.GetComponent<CameraControl>().cameraDistance = distance;
                        StartCoroutine(wait2Sec());

                        break;
                    case Enter_Out_DIRECTION.BACK:
                        mainCamera.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.FRONT;
                        mainCamera.GetComponent<CameraControl>().cameraDistance = distance;
                        StartCoroutine(wait2Sec());

                        break;
                    case Enter_Out_DIRECTION.FRONT:
                        mainCamera.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.BACK;
                        mainCamera.GetComponent<CameraControl>().cameraDistance = distance;
                        StartCoroutine(wait2Sec());

                        break;


                }

                SetCamera();
                
            }
         
            


        }
    }

    IEnumerator wait2Sec()
    {
        mainCamera.gameObject.GetComponent<CameraControl>().isChase = false;
        yield return new WaitForSeconds(2f);
        mainCamera.gameObject.GetComponent<CameraControl>().isChase = true;
        
    }
        
 
}
