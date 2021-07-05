using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    //씬 전환 페이드 함수
    public Image FadeImg;   //페이드 효과에 사용할 이미지

    void Start()
    {
        //게임이 시작되면 페이드인 함수 실행
        FadeIn();
    }

    //페이드인 함수(투명도: 100- > 0)
    public void FadeIn()
    {
        StartCoroutine(CoFadeIn(FadeImg)); //페이드인 코루틴 실행
    }

    //페이드아웃 함수(투명도: 0- > 100)
    public void FadeOut()
    {
        StartCoroutine(CoFadeOut(FadeImg)); //페이드아웃 코루틴 실행
    }

    //페이드인 코루틴 함수
    IEnumerator CoFadeIn(Image fadeImg)
    {
        float fadeAlpha = 1.0f;   //처음 알파값

        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.1f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            fadeImg.color = new Color(0, 0, 0, fadeAlpha);
        }
    }

    //페이드아웃 코루틴 함수
    IEnumerator CoFadeOut(Image fadeImg)
    {
        float fadeAlpha = 0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.1f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            fadeImg.color = new Color(0, 0, 0, fadeAlpha);
        }
    }
}
