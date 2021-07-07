using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
   
    //�� ��ȯ ��ũ��Ʈ 

    //Ÿ��Ʋ ������ �̵�
    public void StartTitleScene()
    {
        StartCoroutine(SceneChangeDelay("Title", 1f));
    }


    //������ ������ �̵�
    public void StartOpeningScene()
    {
        // ����� ��� ���� 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.GetInt("SaveDay", 0);    //������ ����
        GameManager.instance.saveDay = 0;
        StartCoroutine(SceneChangeDelay("Opening_Animation", 1f));
    }

    //day1 ������ �̵�
    public void StartDay1Scene()
    {
        // ����� ��� ���� 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        StartCoroutine(SceneChangeDelay("Day1", 1f));
    }

    //day2 ������ �̵�
    public void StartDay2Scene()
    {
        // ����� ��� ���� 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        PlayerPrefs.SetInt("SaveDay", 1);    //������ ����
        GameManager.instance.saveDay = 1;
        StartCoroutine(SceneChangeDelay("Day2", 1f));
    }

    //day3 ������ �̵�
    public void StartDay3Scene()
    { 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 2);    //������ ����
        GameManager.instance.saveDay = 2;
        StartCoroutine(SceneChangeDelay("Day3", 1f));
    }

    //day4 ������ �̵�
    public void StartDay4Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 3);    //������ ����
        GameManager.instance.saveDay = 3;
        StartCoroutine(SceneChangeDelay("Day4", 1f));
    }

    //day5 ������ �̵�
    public void StartDay5Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 4);    //������ ����
        GameManager.instance.saveDay = 4;
        StartCoroutine(SceneChangeDelay("Day5", 1f));
    }

    //day6 ������ �̵�
    public void StartDay6Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 5);    //������ ����
        GameManager.instance.saveDay = 5;
        StartCoroutine(SceneChangeDelay("Day6", 1f));
    }

    //day7 ������ �̵�
    public void StartDay7Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 6);    //������ ����
        GameManager.instance.saveDay = 6;
        StartCoroutine(SceneChangeDelay("Day7", 1f));
    }

    //�Ѵ� �� ������ �̵�
    public void StartAfterOneMonthScene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 7);    //������ ����
        GameManager.instance.saveDay = 7;
        StartCoroutine(SceneChangeDelay("AfterOneMonth", 1f));
    }

    //���� ������ �� ������ �̵�
    public void StartBeforeOneWeekScene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 8);    //������ ����
        GameManager.instance.saveDay = 8;
        StartCoroutine(SceneChangeDelay("BeforeOneWeek", 1f));
    }


    //Day1 �ִϸ��̼� ������ �̵�
    public void StartAnimationDay1Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day1", 1f));
    }

    //Day2 �ִϸ��̼� ������ �̵�
    public void StartAnimationDay2Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day2", 1f));
    }

    //Day3 �ִϸ��̼� ������ �̵�
    public void StartAnimationDay3Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day3", 1f));
    }

    //Day4 �ִϸ��̼� ������ �̵�
    public void StartAnimationDay4Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day4", 1f));
    }

    //Day5 �ִϸ��̼� ������ �̵�
    public void StartAnimationDay5Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day5", 1f));
    }

    //Day6 �ִϸ��̼� ������ �̵�
    public void StartAnimationDay6Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day6", 1f));
    }

    //Day7 �ִϸ��̼� ������ �̵�
    public void StartAnimationDay7Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day7", 1f));
    }

    //�ν�Ÿ �ǵ� ������ �̵�
    public void StartAnimationInstaScene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_BeforeOneWeek", 1f));
    }

    //���� ũ���� ������ �̵�
    public void StartEndingCredits()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("EndingCredits", 1f));
    }

    //���̵� �� �� �ʰ� �����̸� �ְ�, ���� ��ȯ�ϴ� �ڷ�ƾ �Լ� 
    IEnumerator SceneChangeDelay(string sceneTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //���̵� �ƿ�
        yield return new WaitForSeconds(delayTime); //������
        SceneManager.LoadScene(sceneTitle); //�� ��ȯ
    }
}
