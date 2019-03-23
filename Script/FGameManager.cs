using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FGameManager : MonoBehaviour
{
    public int coinScore = 0;
    public Text scoreText;
    public bool hurted = false;
    public GameObject[] hearts;

    AudioSource playerAudio;    //coin sound
    public AudioClip AddHeartSound;
    public AudioSource RemoveHeartSound;
    public AudioSource PlatformerBgm;
    public AudioSource EndingBgm;
    public AudioSource ChaseBgm;
    public AudioSource gameoverBgm;
    public AudioSource savePointBgm;
    public AudioSource[] bgms;


    //for checking game over
    GameObject player;
    Transform playerPos; //position of player
    Vector3 posOnFloor; //position of player before jump or falling
    bool isGameOver;
    bool isPlayerFloor;

    public Vector3 startPosition;
    bool inGameover = false;

    //fade in(out)
    public GameObject fadeEffectUI;
    GameObject fadeIn;
    public GameObject gameoverText;
   
    FadeEffect fadeScript;
    bool isFade = false;

    //respawn
    public SavePoint savePoint;

    public static FGameManager instance;

    //for caching
    Transform playerTrans;
    PlayerMove_refine playerScript;

    //Packman Gameover Control
    private PackmanControl packmanControl;
    private ChasePackman chasePackman;


    // Use this for initialization
    void Start()
    {
        //bgm
        bgms = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource>();
        PlatformerBgm = bgms[1];
        ChaseBgm = bgms[2];
        EndingBgm = bgms[3];
        RemoveHeartSound = bgms[4];
        gameoverBgm = bgms[5];
        savePointBgm = bgms[6];

        scoreText.text = "Coin   x " + coinScore.ToString();
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMove_refine>();
        playerTrans = player.GetComponent<Transform>();
        playerAudio = player.GetComponent<AudioSource>();
        savePoint = player.GetComponent<SavePoint>();
        fadeScript = fadeEffectUI.transform.GetChild(1).gameObject.GetComponent<FadeEffect>();

        // FadeIn 캐싱
        fadeIn = fadeEffectUI.transform.GetChild(0).gameObject;
        // FadeIn 실행
        fadeIn.SetActive(true);
        fadeEffectUI.transform.GetChild(0).GetComponent<FadeEffect>().StartFade();

        //for gameover
        startPosition = player.GetComponent<Transform>().position;

        //Packman Control
        packmanControl = GameObject.Find("PackmanManager").GetComponent<PackmanControl>();
        chasePackman = GameObject.Find("CollisionBox").GetComponent<ChasePackman>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (hurted == true)  //if character is damaged (include falling)
        {
            RemoveHeart();
        }
        //if (player. == false)
        //{
        //    posOnFloor = playerPos.position;
        //    if(playerPos.position.y < posOnFloor.y - 7f)
        //    {
        //        RemoveHeart();
        //    }
        //}
        if (isGameOver == true)
        {
            GameOver();
        }
        if (coinScore >= 50)
        {
            AddHeart();

        }

        if((inGameover == true) && (Input.GetButtonDown("Jump"))){
            startAfterGameover();
        }

        if ((isFade == true && fadeEffectUI.transform.GetChild(1).gameObject.activeSelf == false))    //respawn
        {
            isFade = false;
            playerTrans.position = savePoint.spawnPoint;
            // FadeIn 실행
            fadeIn.SetActive(true);
            fadeEffectUI.transform.GetChild(0).GetComponent<FadeEffect>().StartFade();
            
            //packman enemy respawn
            packmanControl.GameOver();

            //세이브포인트 시점 설정
            switch (savePoint.GetSaveCount())
            {
                case 0:
                    Camera.main.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.BACK;
                    Camera.main.GetComponent<CameraControl>().cameraDistance = 8;
                    break;
                case 1:
                    Camera.main.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.RIGHT;
                    Camera.main.GetComponent<CameraControl>().cameraDistance = 8;
                    break;
                case 2:
                    Camera.main.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.FRONT;
                    Camera.main.GetComponent<CameraControl>().cameraDistance = 8;
                    break;
            }

        }

        /*
        * packman control(hit)
        * */
        if (chasePackman != null)
        {
            if (chasePackman.IsHit())
            {
                hurted = true;
                isFade = false;
                playerTrans.position = savePoint.spawnPoint;
                // FadeIn 실행
                fadeIn.SetActive(true);
                fadeEffectUI.transform.GetChild(0).GetComponent<FadeEffect>().StartFade();
                packmanControl.GameOver();
            }
        }


    }

    public void AddCoinScore()
    {
        coinScore++;
        scoreText.text = "Coin   x " + coinScore.ToString();
        playerAudio.Play();
    }

    void AddHeart()
    {
        if (hearts[0].activeSelf == true)
        {
            //do nothing
        }
        else if (hearts[1].activeSelf == true)
        {
            coinScore = coinScore - 50;
            scoreText.text = "Coin   x " + coinScore.ToString();
            hearts[0].SetActive(true);
            AudioSource.PlayClipAtPoint(AddHeartSound, Camera.main.transform.position);
        }
        else if (hearts[2].activeSelf == true)
        {
            coinScore = coinScore - 50;
            scoreText.text = "Coin   x " + coinScore.ToString();
            hearts[1].SetActive(true);
            AudioSource.PlayClipAtPoint(AddHeartSound, Camera.main.transform.position);
        }
        else if (hearts[3].activeSelf == true)
        {
            coinScore = coinScore - 50;
            scoreText.text = "Coin   x " + coinScore.ToString();
            hearts[2].SetActive(true);
            AudioSource.PlayClipAtPoint(AddHeartSound, Camera.main.transform.position);
        }
        else if (hearts[4].activeSelf == true)
        {
            coinScore = coinScore - 50;
            scoreText.text = "Coin   x " + coinScore.ToString();
            hearts[3].SetActive(true);
            AudioSource.PlayClipAtPoint(AddHeartSound, Camera.main.transform.position);
        }
        else
        {
            coinScore = coinScore - 50;
            scoreText.text = "Coin   x " + coinScore.ToString();
            hearts[4].SetActive(true);
            AudioSource.PlayClipAtPoint(AddHeartSound, Camera.main.transform.position);
        }
    }

    void RemoveHeart()
    {
        if (hearts[0].activeSelf == true)
        {
            hearts[0].SetActive(false);
            hurted = false;
            RemoveHeartSound.Play();

        }
        else if (hearts[1].activeSelf == true)
        {
            hearts[1].SetActive(false);
            hurted = false;
            RemoveHeartSound.Play();
        }
        else if (hearts[2].activeSelf == true)
        {
            hearts[2].SetActive(false);
            hurted = false;
 //           AudioSource.PlayClipAtPoint(RemoveHeartSound, Camera.main.transform.position);

        }
        else if (hearts[3].activeSelf == true)
        {
            hearts[3].SetActive(false);
            hurted = false;
            RemoveHeartSound.Play();
        }
        else if (hearts[4].activeSelf == true)
        {
            hearts[4].SetActive(false);
            hurted = false;
            RemoveHeartSound.Play();
        }
        else
        {
            isGameOver = true;
            hurted = false;
            return;
        }
    }

    void startAfterGameover()
    {
        playerScript.enabled = true;
        playerTrans.position = startPosition;
        hearts[0].SetActive(true);
        hearts[1].SetActive(true);
        hearts[2].SetActive(true);
        hearts[3].SetActive(true);
        hearts[4].SetActive(true);
        gameoverBgm.Stop();
        PlatformerBgm.Play();

        isFade = false;
        /*
        fadeIn.SetActive(true);
        fadeEffectUI.transform.GetChild(0).GetComponent<FadeEffect>().StartFade();
        */
        fadeIn.SetActive(false);
        fadeEffectUI.transform.GetChild(1).GetComponent<FadeEffect>().StartFade();
        fadeEffectUI.transform.GetChild(1).gameObject.SetActive(false);

        inGameover = false;
        gameoverText.SetActive(false);

        playerScript.enabled = true;

       Camera.main.GetComponent<CameraControl>().currentCamera = CameraControl.CAMERA_POSITION.BACK;
       Camera.main.GetComponent<CameraControl>().cameraDistance = 8;


    }

    void GameOver()
    {
        PlatformerBgm.Stop();
        ChaseBgm.Stop();
        gameoverBgm.Play();
        fadeEffectUI.transform.GetChild(1).gameObject.SetActive(true);
        fadeEffectUI.transform.GetChild(1).GetComponent<FadeEffect>().StartFade();
        isFade = true;
        isGameOver = false;
        inGameover = true;
        gameoverText.SetActive(true);
        playerScript.enabled = false;
        savePoint.spawnPoint = startPosition;
    }

    public void RespawnCharacter()
    {
        isFade = true;
    }
}