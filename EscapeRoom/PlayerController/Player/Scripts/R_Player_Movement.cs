using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotSpeed = 200.0f;
    public float jumpSpeed = 250.0f;

    // 움직임 제한하는 변수
    bool isMove = true;
    bool isJump = true;

    void FixedUpdate()
    {
        //앞뒤 이동
        if (isMove)
        {
            //좌우 회전
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotSpeed*Time.deltaTime);
            if(Input.GetAxis("Vertical")!=0)
            {
                transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
                //GetComponent<Animator>().SetBool("Run", true);
            }
            else
            {
                //GetComponent<Animator>().SetBool("Run", false);
            }

            //점프
            //if (Input.GetButtonDown("Jump") && transform.position.y < 1.1f)
            //{
            //    transform.GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0);
            //}

            if (Input.GetButtonDown("Jump") && isJump)
            {
                transform.GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0);
                isJump = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Floor")
        {
            isJump = true;
        }
    }

    public void SetMove(bool isMove)
    {
        this.isMove = isMove;
    }
}
