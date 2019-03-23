using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour {

    // 켜고 끌 Light 오브젝트
    public GameObject light;
    public GameObject buttonUI;

    private RectTransform buttonUIPos;

	// Use this for initialization
	void Start () {
        buttonUIPos = buttonUI.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 
    private void OnMouseOver()
    {
        // 물체에 닿으면 버튼 UI 생성
        buttonUI.SetActive(true);
        
        // 커서 없애고
        buttonUIPos.position = Input.mousePosition;
    }
    private void OnMouseExit()
    {
        buttonUI.SetActive(false);
    }
}
