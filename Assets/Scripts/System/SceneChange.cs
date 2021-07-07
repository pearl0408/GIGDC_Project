using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
   
    //씬 전환 스크립트 

    //타이틀 씬으로 이동
    public void StartTitleScene()
    {
        StartCoroutine(SceneChangeDelay("Title", 1f));
    }


    //오프닝 씬으로 이동
    public void StartOpeningScene()
    {
        // 오디오 출력 멈춤 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.GetInt("SaveDay", 0);    //데이터 저장
        GameManager.instance.saveDay = 0;
        StartCoroutine(SceneChangeDelay("Opening_Animation", 1f));
    }

    //day1 씬으로 이동
    public void StartDay1Scene()
    {
        // 오디오 출력 멈춤 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        StartCoroutine(SceneChangeDelay("Day1", 1f));
    }

    //day2 씬으로 이동
    public void StartDay2Scene()
    {
        // 오디오 출력 멈춤 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        PlayerPrefs.SetInt("SaveDay", 1);    //데이터 저장
        GameManager.instance.saveDay = 1;
        StartCoroutine(SceneChangeDelay("Day2", 1f));
    }

    //day3 씬으로 이동
    public void StartDay3Scene()
    { 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 2);    //데이터 저장
        GameManager.instance.saveDay = 2;
        StartCoroutine(SceneChangeDelay("Day3", 1f));
    }

    //day4 씬으로 이동
    public void StartDay4Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 3);    //데이터 저장
        GameManager.instance.saveDay = 3;
        StartCoroutine(SceneChangeDelay("Day4", 1f));
    }

    //day5 씬으로 이동
    public void StartDay5Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 4);    //데이터 저장
        GameManager.instance.saveDay = 4;
        StartCoroutine(SceneChangeDelay("Day5", 1f));
    }

    //day6 씬으로 이동
    public void StartDay6Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 5);    //데이터 저장
        GameManager.instance.saveDay = 5;
        StartCoroutine(SceneChangeDelay("Day6", 1f));
    }

    //day7 씬으로 이동
    public void StartDay7Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 6);    //데이터 저장
        GameManager.instance.saveDay = 6;
        StartCoroutine(SceneChangeDelay("Day7", 1f));
    }

    //한달 후 씬으로 이동
    public void StartAfterOneMonthScene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 7);    //데이터 저장
        GameManager.instance.saveDay = 7;
        StartCoroutine(SceneChangeDelay("AfterOneMonth", 1f));
    }

    //개강 일주일 전 씬으로 이동
    public void StartBeforeOneWeekScene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        PlayerPrefs.SetInt("SaveDay", 8);    //데이터 저장
        GameManager.instance.saveDay = 8;
        StartCoroutine(SceneChangeDelay("BeforeOneWeek", 1f));
    }


    //Day1 애니메이션 씬으로 이동
    public void StartAnimationDay1Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day1", 1f));
    }

    //Day2 애니메이션 씬으로 이동
    public void StartAnimationDay2Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day2", 1f));
    }

    //Day3 애니메이션 씬으로 이동
    public void StartAnimationDay3Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day3", 1f));
    }

    //Day4 애니메이션 씬으로 이동
    public void StartAnimationDay4Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day4", 1f));
    }

    //Day5 애니메이션 씬으로 이동
    public void StartAnimationDay5Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day5", 1f));
    }

    //Day6 애니메이션 씬으로 이동
    public void StartAnimationDay6Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day6", 1f));
    }

    //Day7 애니메이션 씬으로 이동
    public void StartAnimationDay7Scene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_Day7", 1f));
    }

    //인스타 피드 씬으로 이동
    public void StartAnimationInstaScene()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("Animation_BeforeOneWeek", 1f));
    }

    //엔딩 크래딧 씬으로 이동
    public void StartEndingCredits()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        StartCoroutine(SceneChangeDelay("EndingCredits", 1f));
    }

    //페이드 후 몇 초간 딜레이를 주고, 씬을 전환하는 코루틴 함수 
    IEnumerator SceneChangeDelay(string sceneTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //페이드 아웃
        yield return new WaitForSeconds(delayTime); //딜레이
        SceneManager.LoadScene(sceneTitle); //씬 전환
    }
}
