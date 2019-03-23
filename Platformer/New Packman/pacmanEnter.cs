using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmanEnter : MonoBehaviour {
    bool isPlayerEnter = false; // 플레이어가 들어온 것을 한번만 검사하기 위한 변수
    public Material sky;
    Color targetSkyColor_skytint;
    Color targetSkyColor_ground;
    Color origiSkyColor_skytint;
    Color originSkyColor_ground;


    float colorChangeLerp = 0.1f;

	// Use this for initialization
	void Start () {

        // color values need to normalized (range 0~255 to 0~1)
        // ground color : origial color is 22,22,56, target color is 113,36,20 
        // sky tint : original color is #48,140,139, target color is 0,2,161
        // shader값은 플레이 도중에 바뀌면 플레이가 꺼져도 다시 돌아오지 않기 때문에 초기화를 미리 해둔다

        originSkyColor_ground = new Color(0.08f, 0.08f, 0.21f);
        origiSkyColor_skytint = new Color(0.18f, 0.54f, 0.54f);

        sky.SetColor("_GroundColor", originSkyColor_ground);
        sky.SetColor("_SkyTint", origiSkyColor_skytint);

        targetSkyColor_ground = new Color(0.44f, 0.14f, 0.07f);
        targetSkyColor_skytint = new Color(0, 0.007f, 0.62f);
	}
	
	// Update is called once per frame
	void Update () {
        if(isPlayerEnter && colorChangeLerp < 1.0f)
        {
            // 플레이어가 pacmanZone에 들어오면 배경색 서서히 체인지
            sky.SetColor("_GroundColor", Color.Lerp(originSkyColor_ground, targetSkyColor_ground, colorChangeLerp));
            sky.SetColor("_SkyTint", Color.Lerp(origiSkyColor_skytint, targetSkyColor_skytint, colorChangeLerp));
            colorChangeLerp += 0.005f;
        }
            
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isPlayerEnter) {

            Debug.Log("player entered in pacman zone");
            isPlayerEnter = true;

        }
    }

}
