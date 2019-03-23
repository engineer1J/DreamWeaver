using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_cameraRot : MonoBehaviour {
    public float lookSensitivity = 5.0f;
    public float minVertical = -5.0f;
    public float maxVertical = 45.0f;

    float yRot;
    float xRot;

    private void Start()
    {
        xRot = transform.localEulerAngles.x;
    }

    void Update()
    {
        if(Input.GetMouseButton(1)) {

        }

    }
    private void LateUpdate()
    {
    }

}
