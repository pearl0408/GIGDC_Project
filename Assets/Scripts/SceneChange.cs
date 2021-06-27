using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    //씬 전환 스크립트 

    //게임 새로하기
    public void StartNewGame()
    {
        StartCoroutine(SceneChangeDelay("Opening", 1f));
    }

    //게임 이어하기
    public void StartSaveGame()
    {
        
    }

    //게임 종료하기
    public void GameExit()
    {
        Application.Quit();
    }

    //페이드 후 몇 초간 딜레이를 주고, 씬을 전환하는 코루틴 함수 
    IEnumerator SceneChangeDelay(string sceneTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //페이드 아웃
        yield return new WaitForSeconds(delayTime); //딜레이
        SceneManager.LoadScene(sceneTitle); //씬 전환
    }
}
