using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconClick : MonoBehaviour {

	//니놈컴퓨터
	//public GameObject myComputer;

	//고양이
	public GameObject cat;

	//알콜코더
	public GameObject mingun;
	
	//폴더 윈도우
	public GameObject folderWindow;

	//sine아이콘
	public GameObject sineIcon;

	//해설집
	public GameObject explanation;

	//해설집 자식들(따로 빼는게 편리해서 분리해서 놓음)
	public GameObject sineStory;

	//File종료버튼
	public GameObject exitIcon;

	//컴퓨터 종료 버튼
	public GameObject exitComputerButton;

	//부모 computer
	public GameObject computer;
	

	//싸인스토리 파일 클릭
	public void SineClick()
	{
		//해설집 활성화(화면에 보여주기)
		sineStory.SetActive(true);
		
		//해설집 종료버튼 활성화
		exitIcon.SetActive(true);

		//컴퓨터 종료버튼 비활성화
		exitComputerButton.SetActive(false);
	}

	public void CatClick()
	{
		cat.SetActive(true);
		exitIcon.SetActive(true);

		//컴퓨터 종료버튼 비활성화
		exitComputerButton.SetActive(false);
	}

	public void MingunClick()
	{

		mingun.SetActive(true);
		exitIcon.SetActive(true);

		//컴퓨터 종료버튼 비활성화
		exitComputerButton.SetActive(false);
	}


	public void FolderClick()
	{
		//폴더창 활성화
		folderWindow.SetActive(true);
		//아이콘 활성화
		sineIcon.SetActive(true);
		//종료버튼 활성화
		exitIcon.SetActive(true);
		
		//컴퓨터 종료버튼 비활성화
		exitComputerButton.gameObject.SetActive(false);

	}

	//파일창 닫는버튼 클릭
	public void SineExit()
	{
		//싸인스토리 모든 파일 비활성화
		explanation.transform.GetChild(0).gameObject.SetActive(false);
		explanation.transform.GetChild(1).gameObject.SetActive(false);
		explanation.transform.GetChild(2).gameObject.SetActive(false);

		//버튼 이것저것 누르다가 싸인스토리 부모 꺼져있는 경우가 발생해서 추가
		explanation.SetActive(true);

		//싸인스토리 비활성화
		//sineIcon.SetActive(false);

		//파일닫기버튼 비활성화 
		gameObject.SetActive(false);

		//컴퓨터 종료버튼 활성화
		if ( mingun.activeSelf == false && cat.activeSelf == false && folderWindow.activeSelf == false)
		{
			exitComputerButton.gameObject.SetActive(true);
		}

	}

	public void FileExit()
	{

		//파일닫기버튼 비활성화
		gameObject.SetActive(false);
		//myComputer.SetActive(false);
		mingun.SetActive(false);
		cat.SetActive(false);


		//컴퓨터 종료버튼 활성화
		if (folderWindow.activeSelf == false)
		{
			exitComputerButton.gameObject.SetActive(true);
		}
	}


	public void FolderCloseClick()
	{

		//아이콘 비활성화
		sineIcon.SetActive(false);
		//폴더창 비활성화
		folderWindow.SetActive(false);
		exitIcon.SetActive(false);

		//컴퓨터 종료버튼 활성화
		if (mingun.activeSelf == false && cat.activeSelf == false) { 
			exitComputerButton.gameObject.SetActive(true);
		}
	}

	public void ShutDownComputerClick()
	{
		computer.SetActive(false);
		//잠금화면 호출
		computer.transform.GetChild(0).gameObject.SetActive(true);
		//일반화면 비활성화(잠금화면 호출을 위한 비활성화)
		computer.transform.GetChild(1).gameObject.SetActive(false);
		//비밀번호 입력창 호출
		computer.transform.GetChild(2).gameObject.SetActive(true);
		//잠금화면에서 ESC버튼 종료를 안만들어 놓을 경우 이거쓰면 됨
		R_GameManager.instance.computerUI.gameObject.SetActive(false);
        R_GameManager.instance.PlayerMovement(true);
        R_GameManager.instance.SetPlayerRotation(true);
    }
}
