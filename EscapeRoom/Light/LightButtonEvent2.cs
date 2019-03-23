using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightButtonEvent2 : MonoBehaviour {

    string nextState = "OFF";
    bool isState = true;

    public Text text;
    public GameObject light;
    public GameObject light2;
    public GameObject Screen;

    public void Button()
    {
        //불 끄기
        if (isState)
        {
            isState = false;
            light.SetActive(false);
            light2.SetActive(true);
            Screen.SetActive(true);
        }
        //불 켜기
        else
        {
            isState = true;
            light.SetActive(true);
            light2.SetActive(false);
            Screen.SetActive(false);
        }
    }

    public void ChangeString()
    {
        text.text = nextState;
    }
}
