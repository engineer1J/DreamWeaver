using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class QuizManagement : MonoBehaviour
{

    public static readonly int MAX_COUNT = 3;
    public static readonly int MAX_IMAGE_COUNT = 4;
    private enum CALC_STATE
    {
        ADD,
        SUBTRACT,
        MULTIPLY,
    }
    private enum CALC_BONUS_STATE
    {
        ADDTREE,
        ADDBOOK,
        SUBTRACT_TREE,
        SUBTRACT_BOOK,
        //ADDCOIN,
        //SUBTRACT_COIN,
        //POW,

    }

    public QuizCube_RotateCube[] quizCubes;
    public GameObject answerCube;
    public SpriteData bonusCubeImage;
    public EnterZone enterZone;
    public BoomPlaneManager boomPlane;
    public CameraControl mainCamera;
    public WallActive wallControl;
    public GameObject EnterZone;


    public bool isTest = false;

    private int int1;     // 숫자
    private string text2;  // 기호
    private int int3;  //숫자
    private string text4;   //보너스 기호 
    private CALC_STATE currentState;
    private CALC_BONUS_STATE currentBouns;
    public int bonusCount = 3;
    public int bookCount;
    private int finalAnswer;
    private int calcAnswer;
    public bool collisionCheck = false;
    public bool isStart = false;
    private CALC_BONUS_STATE currentBonus;




    // Use this for initialization
    void Start()
    {
        currentBouns = CALC_BONUS_STATE.ADDTREE; //임시
        RandomGenerate();
        getCubesItem();
        answerCube.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(finalAnswer.ToString());
        enterZone = transform.Find("Entrance_Zone").gameObject.GetComponent<EnterZone>();
        boomPlane = transform.Find("BoomPlane").gameObject.GetComponent<BoomPlaneManager>();
        mainCamera = Camera.main.GetComponent<CameraControl>();
        wallControl = transform.Find("Wall").gameObject.GetComponent<WallActive>();
        wallControl.SetActive(false);
        EnterZone = transform.Find("Entrance_Zone").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        getCubesItem();

        if (collisionCheck)
        {
            AnswerButtonTouched();
            collisionCheck = false;
        }

        if(enterZone.GetIsEnter())
        {
            
            PlayerEnter();
            enterZone.SetIsEnter(false);
        }

        if(isTest)
        {
            AnswerButtonTouched();
            isTest = false;
        }
        if(isStart)
        {
            PlayerEnter();
            isStart = false;
        }


    }

    void getCubesItem()
    {
        int1 = quizCubes[0].result;
        text2 = quizCubes[1].result_s;


        if (text2.Equals("+"))
        {
            currentState = CALC_STATE.ADD;
        }
        else if (text2.Equals("-"))
        {
            currentState = CALC_STATE.SUBTRACT;
        }
        else if (text2.Equals("X"))
        {
            currentState = CALC_STATE.MULTIPLY;
        }

        int3 = quizCubes[2].result;
        //text4 = quizCubes[3].result_s;
    }

    int CubeCalc()
    {
        int result = 0;

        if (currentState == CALC_STATE.ADD)
        {
            //Debug.Log("case : add");
            result = int1 + int3;
            return result;
        }
        else if (currentState == CALC_STATE.SUBTRACT)
        {
            //Debug.Log("case : sub");
            result = int1 - int3;
            return result;
        }
        else if (currentState == CALC_STATE.MULTIPLY)
        {
            //Debug.Log("case : mult");
            result = int1 * int3;
            return result;
        }

        return result;
    }

 


    int BounusCubeCalc(int calcValue)
    {
        int result = calcValue;

        switch (currentBouns)
        {
            case CALC_BONUS_STATE.ADDTREE:
                result += bonusCount;
               // Debug.Log("bonusCount on");
               // Debug.Log("bonusCount = " + bonusCount);
                break;
        }

        return result;

    }


    public void AnswerButtonTouched()
    {

        getCubesItem();
        calcAnswer = CubeCalc();
        calcAnswer = BounusCubeCalc(calcAnswer);
        if((finalAnswer == calcAnswer) || isTest)
        {
            Debug.Log("맞춤");
            boomPlane.SetEnd(true);
            wallControl.SetActive(false);

        }
        else
        {
            Debug.Log("못 맞춤");
        }

    }

    private void RandomGenerate()
    {
        System.Random random = new System.Random();
      

        for (int i = 0; i < MAX_COUNT; i++)
        {
            if (i != 1) //+-*/ 부호를 표시하는 부분을 제외하고
            {
                quizCubes[i].textMeshProArray[0].SetText(random.Next(0, 16).ToString());
                quizCubes[i].textMeshProArray[1].SetText(random.Next(0, 16).ToString());
                quizCubes[i].textMeshProArray[2].SetText(random.Next(0, 16).ToString());
                quizCubes[i].textMeshProArray[3].SetText(random.Next(0, 16).ToString());
            }
        }

        quizCubes[1].textMeshProArray[0].SetText("+");
        quizCubes[1].textMeshProArray[1].SetText("-");
        quizCubes[1].textMeshProArray[2].SetText("X");
        quizCubes[1].textMeshProArray[3].SetText("+");

        
        switch(random.Next(0, MAX_IMAGE_COUNT))
        {


            case 0:
                currentBonus = CALC_BONUS_STATE.ADDBOOK;
                bonusCubeImage.GetComponent<SpriteData>().SetImage(0); //보너스 문제
                break;
            case 1:
                currentBonus = CALC_BONUS_STATE.SUBTRACT_BOOK;
                bonusCubeImage.GetComponent<SpriteData>().SetImage(1); //보너스 문제
                break;
            case 2:
                currentBonus = CALC_BONUS_STATE.ADDTREE;
                bonusCubeImage.GetComponent<SpriteData>().SetImage(2); //보너스 문제
                break;
            case 3:
                currentBonus = CALC_BONUS_STATE.SUBTRACT_TREE;
                bonusCubeImage.GetComponent<SpriteData>().SetImage(3); //보너스 문제
                break;
        }


        int j = random.Next(0, 4);
        int randomInt1;
        int.TryParse(quizCubes[0].textMeshProArray[j].text, out randomInt1);
        int randomInt3;
        int.TryParse(quizCubes[2].textMeshProArray[j].text, out randomInt3);
        string randomMark;
        randomMark = quizCubes[1].textMeshProArray[j].text;
        
        switch(randomMark)
        {
            case "+":
                finalAnswer = randomInt1 + randomInt3;
                break;
            case "-":
                finalAnswer = randomInt1 - randomInt3;
                break;
            case "X":
                finalAnswer = randomInt1 * randomInt3;
                break;
        }

        finalAnswer += bonusCount;

    }

    void PlayerEnter() //Game zone에 플레이어가 진입
    {
        for(int i=0; i< MAX_COUNT; i++)
        {
            quizCubes[i].Init();
        }
        boomPlane.SetStart(true);
        mainCamera.CameraSet(10, 3);
        wallControl.SetActive(true);
        EnterZone.SetActive(false);
    }

    void PlayerFail()
    {
        for (int i = 0; i < MAX_COUNT; i++)
        {
            quizCubes[i].Init();
        }
        boomPlane.SetStart(false);
        mainCamera.CameraSet(8f, 5.5f);
        wallControl.SetActive(false);
        EnterZone.SetActive(true);
    }
}

