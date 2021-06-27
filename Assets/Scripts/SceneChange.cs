using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    //�� ��ȯ ��ũ��Ʈ 

    //���� �����ϱ�
    public void StartNewGame()
    {
        StartCoroutine(SceneChangeDelay("Opening", 1f));
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

    //���̵� �� �� �ʰ� �����̸� �ְ�, ���� ��ȯ�ϴ� �ڷ�ƾ �Լ� 
    IEnumerator SceneChangeDelay(string sceneTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //���̵� �ƿ�
        yield return new WaitForSeconds(delayTime); //������
        SceneManager.LoadScene(sceneTitle); //�� ��ȯ
    }
}
