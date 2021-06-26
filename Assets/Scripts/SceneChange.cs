using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //게임 새로하기
    public void StartNewGame()
    {
        SceneManager.LoadScene("Opening");  //오프닝 애니메이션 씬으로 이동
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
}
