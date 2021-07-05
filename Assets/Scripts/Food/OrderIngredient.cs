using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Ingredients { egg, ketchup, rice, noodle, shrimp, tomato, bread, bacon, cheese, herb, meat, pepper};    //재료 열거형 변수 정의

public class OrderIngredient : MonoBehaviour
{
    //재료를 선택하고 주문하는 함수
    static List<Ingredients> selectIngredients = new List<Ingredients>();  //선택한 재료 리스트
    int numberOfSelect; //선택한 개수


    void Start()
    {
        numberOfSelect = 0;
    }

    //세 가지 재료를 선택했다면 주문하는 함수(주문하기 버튼 이벤트)
    public void OrderThreeIngredient()
    {
        if (numberOfSelect == 3)    //선택한 재료가 3개라면
        {
            if (selectIngredients.Contains(Ingredients.egg) && selectIngredients.Contains(Ingredients.ketchup) && selectIngredients.Contains(Ingredients.rice))    //오므라이스 재료가 다 선택됐다면
            {
                GameManager.instance.orderFood = "Omelet"; 
            }
            else if (selectIngredients.Contains(Ingredients.noodle) && selectIngredients.Contains(Ingredients.shrimp) && selectIngredients.Contains(Ingredients.tomato))  //파스타 재료가 다 선택됐다면
            {
                GameManager.instance.orderFood = "Pasta";
            }
            else if (selectIngredients.Contains(Ingredients.bread) && selectIngredients.Contains(Ingredients.bacon) && selectIngredients.Contains(Ingredients.cheese))  //샌드위치 재료가 다 선택됐다면
            {
                GameManager.instance.orderFood = "Sandwich";
            }
            else if (selectIngredients.Contains(Ingredients.herb) && selectIngredients.Contains(Ingredients.meat) && selectIngredients.Contains(Ingredients.pepper))  //스테이크 재료가 다 선택됐다면
            {
                GameManager.instance.orderFood = "Steak";
            }
            else    //재료 선택이 틀렸다면 선택 초기화
            {
                GameManager.instance.orderFood = "";
                ResetSelect();
            }
        }
        else    //아니라면 선택 초기화
        {
            GameManager.instance.orderFood = "";
            ResetSelect();
        }
    }

    //선택된 재료를 선택 해제 하는 함수(주문하기 버튼 실패시)
    public void ResetSelect()
    {
        selectIngredients.Clear();    //리스트 지우기
        numberOfSelect = 0;

        for (int i = 0; i < 12; i++)
        {
            //버튼 색깔 바꾸기
            this.transform.GetChild(i).gameObject.GetComponent<SelectIngredient>().ResetThisSelect();    //버튼 누름 상태 해제
        }
    }

    //재료를 추가하는 함수
    public void AddList(Ingredients content)
    {
        selectIngredients.Add(content); //재료 추가
        numberOfSelect++;
    }

    //재료를 삭제하는 함수
    public void DeleteList(Ingredients content)
    {
        selectIngredients.Remove(content);  //재료 삭제
        numberOfSelect--;
    }
}
