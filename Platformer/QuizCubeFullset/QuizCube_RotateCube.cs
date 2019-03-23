using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class QuizCube_RotateCube : MonoBehaviour {

    public int degree = 0; //회전각(기본 90도)
    public float speed = 4;
    public int result = 0;
    public string result_s = "";
    Vector3 targetVector;
    Transform targetTrans;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;
    public TextMeshPro[] textMeshProArray;
    public int textMeshCount = 3;
    public static readonly int MAX_COUNT = 4;
    private QuizManagement quizCubeManager;

    Color32 black;
    Color32 green;


    // Use this for initialization
    void Start () {
        
        targetVector = transform.position;
        text1 = transform.GetChild(0).GetComponent<TextMeshPro>();
        text2 = transform.GetChild(1).GetComponent<TextMeshPro>();
        text3 = transform.GetChild(2).GetComponent<TextMeshPro>();
        text4 = transform.GetChild(3).GetComponent<TextMeshPro>();
        textMeshProArray = new TextMeshPro[MAX_COUNT];

        textMeshProArray[0] = text1; textMeshProArray[1] = text2; textMeshProArray[2] = text3; textMeshProArray[3] = text4;

        black = new Color32(0, 0, 0, 255);
        green = new Color32(0, 183, 0, 255);

        quizCubeManager = gameObject.GetComponentInParent<QuizManagement>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator RotateCube(Quaternion targetRotation, float destinationTime)
    {
        float curTime = 0;
        
        while (curTime < destinationTime)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, curTime / destinationTime); //뭔가 잘못되었다
            curTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }


    }

    void OnCollisionEnter(Collision col) //주의, 에어리어 진입 시 무조건 한번 collision을 건드려 줘야 초기화됨
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (textMeshCount < 0)
            {
                textMeshCount = MAX_COUNT - 1;
            }

            degree += 90;

            Quaternion targetRotation = transform.rotation;
            targetRotation = Quaternion.Euler(0, degree, 0);


            targetTrans = transform.transform;
            targetTrans.rotation = targetRotation;


            float step = speed * Time.deltaTime;
            //StartCoroutine(RotateCube(targetRotation, 2f));
            transform.rotation = targetRotation;
            
            if (textMeshProArray[textMeshCount].text.Equals("X")
                || textMeshProArray[textMeshCount].text.Equals("+") || textMeshProArray[textMeshCount].text.Equals("-")
                || textMeshProArray[textMeshCount].text.Equals(""))
            {
                result_s = textMeshProArray[textMeshCount].text;
            }
            else
            {
                //int result;
                int.TryParse(textMeshProArray[textMeshCount].text, out result);
            }

            ColorClear();


            textMeshProArray[textMeshCount].color = green;
            textMeshCount--;
            //Debug.Log("textmeshcount : " + textMeshCount);


            quizCubeManager.AnswerButtonTouched();
            //Debug.Log("Rotate!");


        }



    }

    public void Init()
    {
            if (textMeshCount < 0)
            {
                textMeshCount = MAX_COUNT - 1;
            }

            degree += 90;

            Quaternion targetRotation = transform.rotation;
            targetRotation = Quaternion.Euler(0, degree, 0);


            targetTrans = transform.transform;
            targetTrans.rotation = targetRotation;


            float step = speed * Time.deltaTime;
            //StartCoroutine(RotateCube(targetRotation, 2f));
            transform.rotation = targetRotation;

            if (textMeshProArray[textMeshCount].text.Equals("X")
                || textMeshProArray[textMeshCount].text.Equals("+") || textMeshProArray[textMeshCount].text.Equals("-")
                || textMeshProArray[textMeshCount].text.Equals(""))
            {
                result_s = textMeshProArray[textMeshCount].text;
            }
            else
            {
                //int result;
                int.TryParse(textMeshProArray[textMeshCount].text, out result);
            }

            ColorClear();


            textMeshProArray[textMeshCount].color = green;
            textMeshCount--;
            //Debug.Log("textmeshcount : " + textMeshCount);

        
    }

    void ColorClear()
    {
        for(int i=0; i< MAX_COUNT; i++)
        {
            textMeshProArray[i].color = black;
        }
    }

}
