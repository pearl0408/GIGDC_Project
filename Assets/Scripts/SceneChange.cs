using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //���� �����ϱ�
    public void StartNewGame()
    {
        SceneManager.LoadScene("Opening");  //������ �ִϸ��̼� ������ �̵�
    }

    //���� �̾��ϱ�
    public void StartSaveGame()
    {
        
    }

    //���� �����ϱ�
    public void GameExit()
    {
        Application.Quit();
    }
}
