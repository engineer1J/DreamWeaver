using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    // �̵��ӵ�
    public float moveSpeed = 7.0f;

    // ���� ����
    public float jumpForce = 280.0f;
    bool isJump = false;

    // ī�޶� ȸ���ӵ�
    public float sensiblityX = 5.0f;
    public float sensiblityY = 5.0f;
    float rotationY = 0.0f;

    // Use this for initialization
    void Start()
    {
        // ī�޶� ȸ���� ���� �Լ�
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �̵�
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime); // �¿� �̵�
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime); // �յ� �̵�

        // ����
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
            isJump = true;
        }

        if (transform.position.y < 100.0f)
        {
            isJump = false;
        }

        // ���콺 ������Ű �������� ī�޶� ȸ��
        if (Input.GetMouseButton(1))
        {
            // �¿� ȸ����
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensiblityX;

            // ���� ȸ����
            rotationY += Input.GetAxis("Mouse Y") * sensiblityY;
            rotationY = Mathf.Clamp(rotationY, -20.0f, 60.0f); // ���̰��� ��ȯ���ִ� �Լ�

            // ȸ���� ����
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}