using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIngredient : MonoBehaviour
{
    //재료를 선택하는 함수(재료 버튼에 이 스크립트 추가)
    public Ingredients thisIngredient;   //해당 재료
    
    public bool isPressed;  //버튼이 눌러졌는지
    GameObject content; //재료 버튼들 부모 오브젝트

    //컬러블록 생성
    ColorBlock unslelctColor;
    ColorBlock selectColor;

    void Start()
    {
        content = this.gameObject.transform.parent.gameObject;
        isPressed = false;  //버튼 상태 초기화

        //컬러블록 지정
        unslelctColor = this.GetComponent<Button>().colors;
        selectColor = this.GetComponent<Button>().colors;

        unslelctColor.normalColor = Color.white;
        //unslelctColor.highlightedColor = Color.white;
        unslelctColor.pressedColor = Color.white;
        unslelctColor.selectedColor = Color.white;

        selectColor.normalColor = Color.yellow;
        //selectColor.highlightedColor = Color.yellow;
        selectColor.pressedColor = Color.yellow;
        selectColor.selectedColor = Color.yellow;
    }

    //해당 재료를 선택한 버튼 이벤트
    public void SelectThisIngredient()
    {
        if (isPressed)  //만약 버튼이 눌러진 상태라면
        {
            content.gameObject.GetComponent<OrderIngredient>().DeleteList(thisIngredient);   //선택한 재료 추가
            ResetThisSelect();
        }
        else    //만약 버튼이 눌러진 상태가 아니라면
        {
            content.gameObject.GetComponent<OrderIngredient>().AddList(thisIngredient);    //선택한 재료 삭제
            SelectThis();
        }
    }

    public void ResetThisSelect()
    {
        this.GetComponent<Button>().colors = unslelctColor;   //버튼 색깔 바꾸기
        isPressed = false;  //버튼 누름 상태 해제
    }

    public void SelectThis()
    {
        this.GetComponent<Button>().colors = selectColor;   //버튼 색깔 바꾸기
        isPressed = true;   //버튼 누름 상태
    }
}
