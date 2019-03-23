using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //move 변수
    public float speed = 5f;
    float yVelocity = 0;
    public float gravity = 14f;
    public float jumpPower = 10f;
    float acc;
    Vector3 moveVector;
    Vector3 moveVector_local;

    CharacterController cc;
    Animator animator;

    Vector3 playerInput;

    //로테이트 변수
    public float lookSensitvity = 5;
    public float lookSmoothDamp = 0.1f;
    float xRotation;
    float yRotation;

    public float rotSpeed = 180.0f;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        playerInput.Set(0f, 0f, Input.GetAxis("Vertical")); //입력한 화살표(좌우, 상하)의 입력값을 Vector3형태로 만듭니다.
        PlayerMove();
        SwitchState();
        Rotate();

    }
    void PlayerMove()
    {
        if (cc.isGrounded)
        {
            acc = gravity;
            yVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity += acc;
                yVelocity = jumpPower;
                acc = 0;
            }
            animator.SetBool("Stand", true);
            animator.SetBool("Jump", false);
        }
        else
        {
            yVelocity -= gravity * Time.deltaTime;
            animator.SetBool("Jump", true);
            animator.SetBool("Stand", false);
            //if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)) Jump();

        }
        moveVector = Vector3.zero;
        moveVector.x = playerInput.x * speed;
        moveVector.y = yVelocity;
        moveVector.z = playerInput.z * speed;

        //캐릭터 컨트롤러의 move는 월드 좌표 기준으로 움직이기 때문에 moveVector를 로컬 기준으로 바꿔주어야 함 
        moveVector_local = transform.TransformDirection(moveVector);
        cc.Move(moveVector_local * Time.deltaTime);

    }

    void SwitchState()
    {

        if (playerInput == Vector3.zero)
        {
            animator.SetBool("Stand", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Stand", false);
            animator.SetBool("Run", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Stand", false);
        }

    }
    void Rotate()
    {
        ////xRotation += -Input.GetAxis("Mouse Y") * lookSensitvity;
        //yRotation += Input.GetAxis("Mouse X") * lookSensitvity;

        ////transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //transform.localRotation = Quaternion.Euler(0, yRotation, 0);

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime);
    }

}
