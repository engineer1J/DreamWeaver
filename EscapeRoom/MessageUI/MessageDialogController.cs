using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDialogController : MonoBehaviour {

    //  변수
    public float typingDelay = 0.1f;
    public float skipDelay = 0.2f;

    // 전체 대화창의 내용 (문자배열)
    string fulltext = "이 꿈의 주인은 학생이다.\n" +
        "\n공부를 하며 반복되는 생활 패턴에 매우 지쳤을 것이다.\n" +
        "\n지금 매우 답답하다. 아마 꿈의 주인인 학생이 이 집에 대해서 답답함을 느끼는 것이겠지.\n" +
        "\n우선 단서를 찾아서 이 방에서 나가자. 의외로 불을 끄면 단서를 쉽게 찾을지도.\n";

    // 전체 대화창의 개수
    int dialog_cnt;

    // 현재 대화창 위치
    //int cnt;

    // 현재 대화창의 전체 내용
    string currentText;

    // 현재 텍스트 타이핑 상태 (full : 끝, cut : 딜레이 생략)
    bool text_full;
    bool text_cut;

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // 최초 텍스트 시작호출
    public void Get_Typing()
    {
        //재사용을 위한 변수초기화
        text_full = false;
        text_cut = false;
        //cnt = 0;

        // 메시지 내용 받아오기
        //fulltext = transform.GetComponent<MessageObject>().GetDialog();

        // 퀴즈 전체 내용 개수 받아오기
        dialog_cnt = fulltext.Length;

        //타이핑 코루틴시작
        StartCoroutine(ShowText(fulltext));
    }

    IEnumerator ShowText(string _fullText)
    {
        //// 모든 텍스트 종료
        //if (text_full)
        //{
        //    //text_exit = true;

        //    // 플레이어 이동/회전 가능
        //    R_GameManager.instance.PlayerMovement(true);
        //    R_GameManager.instance.SetPlayerRotation(true);

        //    // 코루틴 중단
        //    StopCoroutine("ShowText");
        //    // MessageUI 비활성화
        //    transform.parent.parent.gameObject.SetActive(false);
        //}
        //else
        //{
            //기존문구clear
            currentText = "";
            
            //타이핑 시작
            for (int i = 0; i < _fullText.Length; i++)
            {
                //타이핑중도탈출
                if (text_cut == true)
                {
                    break;
                }

                //현재 텍스트에 한글자씩 추가로 적기
                currentText = _fullText.Substring(0, i + 1);
                text.text = currentText;
                yield return new WaitForSeconds(typingDelay);
            }

            // 타이핑이 끝나면 모든 문자출력

            //Debug.Log("Typing 종료");
            if(text_full == false)
            {
                text.text = _fullText;
                yield return new WaitForSeconds(skipDelay);
            }

            //스킵_지연후 종료
            text_full = true;
        //}
    }

    // 다음 버튼 함수와 연결짓기
    public void Next_Typing()
    {
        //// 현재 텍스트 모두 출력하고 버튼 클릭시
        //if (text_full == true)
        //{
        //    //cnt++;
        //    text_full = false;
        //    text_cut = false;
        //    // 왜 이렇게 하는거지?
        //    StartCoroutine(ShowText(fulltext));
        //}
        ////텍스트 타이핑 생략
        //else
        //{
            text_cut = true;
        if(text_full==true)
        {
            R_GameManager.instance.PlayerMovement(true);
            R_GameManager.instance.SetPlayerRotation(true);
        StopCoroutine("ShowText");
        transform.parent.parent.gameObject.SetActive(false);

        }
        //}
    }
}