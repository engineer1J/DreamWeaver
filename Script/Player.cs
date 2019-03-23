using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // 이동속도
    public float moveSpeed = 7.0f;

    // 점프 강도
    public float jumpForce = 280.0f;
    bool isJump = false;

    // 카메라 회전속도
    public float sensiblityX = 5.0f;
    public float sensiblityY = 5.0f;
    float rotationY = 0.0f;

    // Use this for initialization
    void Start()
    {
        // 카메라 회전을 위한 함수
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 이동
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime); // 좌우 이동
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime); // 앞뒤 이동

        // 점프
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
            isJump = true;
        }

        if (transform.position.y < 100.0f)
        {
            isJump = false;
        }

        // 마우스 오른쪽키 누른상태 카메라 회전
        if (Input.GetMouseButton(1))
        {
            // 좌우 회전값
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensiblityX;

            // 상하 회전값
            rotationY += Input.GetAxis("Mouse Y") * sensiblityY;
            rotationY = Mathf.Clamp(rotationY, -20.0f, 60.0f); // 사이값을 반환해주는 함수

            // 회전값 적용
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}
