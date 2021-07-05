using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    Color c, tc; //배경과 택스트 칼라
    public Text message; //텍스트
    
    //페이드 인
    IEnumerator fadein()
    {
        for (float f = 0; f <= 1; f += 0.1f)
        {
            c = gameObject.GetComponent<Image>().color; //배경 이미지 컬러 받아오기
            tc= message.GetComponent<Text>().color; //텍스트 이미지 컬러 받아오기          
            c.a = f; //알파값 설정
            tc.a = f; //알파값 설정
            message.GetComponent<Text>().color = tc; //바뀐 알파값 적용하기(텍스트)
            gameObject.GetComponent<Image>().color = c; //바뀐 알파값 적용하기(배경)

            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        StartCoroutine(fadeout()); //페이드 아웃 시작

    }

    //페이드 아웃
    IEnumerator fadeout()
    {
        yield return new WaitForSeconds(1.0f);

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            
            c = gameObject.GetComponent<Image>().color; //배경 이미지 컬러 받아오기
            tc = message.GetComponent<Text>().color; //텍스트 이미지 컬러 받아오기
            c.a = f; //알파값 설정
            tc.a = f; //알파값 설정
            message.GetComponent<Text>().color = tc; //바뀐 알파값 적용하기(텍스트)
            gameObject.GetComponent<Image>().color = c; //바뀐 알파값 적용하기(배경)

            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        gameObject.SetActive(false); //SetActive=false
    }

    //음식광고를 클릭하면 실행(버튼 onClick)
    public void ToastButton1()
    {
        gameObject.SetActive(true); //SetActive=true
        //message = GameObject.Find("message"); //텍스트 찾기
        message.text = "당일 점포 휴일";  //텍스트 변경
        Vibration.Vibrate(100); // 진동함수
        StartCoroutine(fadein()); //페이드 인 시작
    }

    public void ToastButton2()
    {
        gameObject.SetActive(true); //SetActive=true
        //message = GameObject.Find("message"); //텍스트 찾기
        message.text = "배달료 20,000원";  //텍스트 변경
        Vibration.Vibrate(100); // 진동함수
        StartCoroutine(fadein()); //페이드 인 시작
    }

    public void ToastButton3()
    {
        gameObject.SetActive(true); //SetActive=true
        //message = GameObject.Find("message"); //텍스트 찾기
        message.text = "평점 1.0";  //텍스트 변경
        Vibration.Vibrate(100); // 진동함수
        StartCoroutine(fadein()); //페이드 인 시작
    }
}
