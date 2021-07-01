using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchFood : MonoBehaviour
{
    //음식 검색하는 스크립트

    public Text text_Keyword;   //키워드 입력창
    public GameObject searchResultPanel;    //검색 결과 패널

    public void TypingOmelet()
    {
        text_Keyword.text = "오믈렛 레시피"; //텍스트 입력
        GameManager.instance.searchFood = "오믈렛";    //싱글톤에 저장
    }

    public void TypingPasta()
    {
        text_Keyword.text = "파스타 레시피"; //텍스트 입력
        GameManager.instance.searchFood = "파스타";    //싱글톤에 저장
    }

    public void TypingSandwich()
    {
        text_Keyword.text = "샌드위치 레시피"; //텍스트 입력
        GameManager.instance.searchFood = "샌드위치";    //싱글톤에 저장
    }

    public void TypingSteak()
    {
        text_Keyword.text = "스테이크 레시피"; //텍스트 입력
        GameManager.instance.searchFood = "스테이크";    //싱글톤에 저장
    }

    //검색 결과를 보여주는 함수(검색 버튼 이벤트)
    public void checkFood()
    {
        string searchKey = text_Keyword.text;   //검색할 텍스트를 가져옴
        if (searchKey != "") //만약 공백이 아니라면
        {
            searchResultPanel.gameObject.SetActive(true);   //검색 결과창 활성화
        }
    }
}
