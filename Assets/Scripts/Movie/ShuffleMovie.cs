using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum movies { action, animation, comedy, drama, horror, romance };    //영화 열거형 변수 정의

public class ShuffleMovie : MonoBehaviour
{
    //영화 목록을 랜덤으로 섞는 스크립트

    public Button[] movieList;   //영화 버튼 목록

    void Start()
    {
        Shuffle(movieList);  //배열 셔플

        //책 버튼 생성
        for (int i = 0; i < 6; i++)
        {
            //버튼 생성
            Button Btn_Movie = (Button)Instantiate(movieList[i]);   //버튼 생성
            Btn_Movie.gameObject.transform.SetParent(this.gameObject.transform); //현재 오브젝트의 자식 오브젝트로 생성
        }
    }

    //셔플 함수
    void Shuffle(Button[] btnArray)
    {
        int random1, random2;   //인덱스
        Button tempBtn; //임시 버튼

        for (int i = 0; i < btnArray.Length; i++)
        {
            random1 = Random.Range(0, btnArray.Length);    //랜덤 인덱스 생성
            random2 = Random.Range(0, btnArray.Length);    //랜덤 인덱스 생성

            tempBtn = btnArray[random1];    //임시 버튼 저장
            btnArray[random1] = btnArray[random2];  //버튼 변경
            btnArray[random2] = tempBtn;    //임시 버튼 변경
        }
    }
}
