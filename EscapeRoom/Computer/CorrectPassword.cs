﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectPassword : MonoBehaviour {

	//public InputField inputPassword;

	private string computerPassword;
	private string correctComputerPassword = "20000207";

	public void InputText(Text password)
	{
		//password.text = inputPassword.text;
		computerPassword = password.text;
	}

	public void CorrectText(Text text)
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if (computerPassword == correctComputerPassword)
			{
				R_GameManager.instance.computerUI.gameObject.SetActive(false);
			}
			else
			{
				computerPassword = null;
			}
		}
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            R_GameManager.instance.PlayerMovement(true);
            R_GameManager.instance.SetPlayerRotation(true);
            gameObject.SetActive(false);
        }
    }
    /*void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if (computerPassword == correctComputerPassword)
			{
				R_GameManager.instance.computerUI.gameObject.SetActive(false);
			}
			else
			{
				computerPassword = null;
			}
		}
	}*/
}
