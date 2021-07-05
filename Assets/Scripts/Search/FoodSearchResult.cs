using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class FoodSearchResult : MonoBehaviour
{
    //음식 검색 결과를 보여주는 스크립트

    public Text searchKeyword;  //검색어 텍스트
    public Text foodNameText;   //음식 이름 텍스트

    public GameObject[] ingredientList; //재료 배열

    public Sprite[] ingredientSprite_Omelet;   // 오믈렛 재료 이미지 배열
    public Sprite[] ingredientSprite_Pasta;   // 파스타 재료 이미지 배열
    public Sprite[] ingredientSprite_Sandwich;   // 샌드위치 재료 이미지 배열
    public Sprite[] ingredientSprite_Steak;   // 스테이크 재료 이미지 배열

    private string[] Omelet_ingredient_Text = { "달걀", "케첩", "쌀",
        "닭이 낳은 알", "토마토를 재료로 만드는 서양식 조미료", "벼 열매의 껍질을 벗긴 알갱이"};  //오믈렛 재료 설명 문자열 배열

    private string[] Pasta_ingredient_Text = { "면", "새우", "토마토",
        "밀가루 등의 반죽을 가늘고 길게 뽑아낸 식품", "십각목 장미아목에 속하는 절지동물의 총칭", "쌍떡잎식물 통화식물목 가지과의 한해살이풀"};  //파스타 설명 문자열 배열

    private string[] Sandwich_ingredient_Text = { "식빵", "베이컨", "치즈",
        "틀에 넣어 구운 흰 빵", "돼지고기를 소금에 절여 훈연한 식품", "우유단백질을 응고시킨 식품" };  //샌드위치 설명 문자열 배열

    private string[] Steak_ingredient_Text = { "허브", "고기", "후추",
        "풍미가 있거나 향이 나는 식물", "동물들의 먹을 수 있는 살", "후추나무의 열매" };  //스테이크 설명 문자열 배열

    //오브젝트가 활성화 될 때마다
    private void OnEnable()
    {
        string searchFood = GameManager.instance.searchFood;    //검색한 음식을 가져옴
        searchKeyword.text = searchFood + " 레시피";   //음식 검색 텍스트 수정

        //검색한 음식에 맞춰 이미지, 텍스트 수정
        if (searchFood == "오믈렛")
        {
            foodNameText.text = "오믈렛";  //요리 이름 수정
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "프랑스의 대표적인 달걀 요리";    //요리 설명 수정

            //재료 이미지, 텍스트 수정
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Omelet[i];  //재료 이미지 수정

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //재료 텍스트 오브젝트를 가져옴
                ingredient_Text.GetComponent<Text>().text = Omelet_ingredient_Text[i];  //재료 이름 수정
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Omelet_ingredient_Text[i + 3];  //재료 설명 수정
            }

        }
        else if (searchFood == "파스타")
        {
            foodNameText.text = "파스타";  //요리 이름 수정
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "물과 밀가루를 사용하여 만드는 이탈리아 국수요리";    //요리 설명 수정

            //재료 이미지, 텍스트 수정
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Pasta[i];  //재료 이미지 수정

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //재료 텍스트 오브젝트를 가져옴
                ingredient_Text.GetComponent<Text>().text = Pasta_ingredient_Text[i];  //재료 이름 수정
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Pasta_ingredient_Text[i + 3];  //재료 설명 수정
            }
        }
        else if (searchFood == "샌드위치")
        {
            foodNameText.text = "샌드위치";  //요리 이름 수정
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "빵 사이에 소스를 바르고 재료를 끼워 넣은 음식";    //요리 설명 수정

            //재료 이미지, 텍스트 수정
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Sandwich[i];  //재료 이미지 수정

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //재료 텍스트 오브젝트를 가져옴
                ingredient_Text.GetComponent<Text>().text = Sandwich_ingredient_Text[i];  //재료 이름 수정
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Sandwich_ingredient_Text[i + 3];  //재료 설명 수정
            }
        }
        else    //searchFood == "스테이크"
        {
            foodNameText.text = "스테이크";  //요리 이름 수정
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "두꺼운 육류 조각을 구운 서양요리";    //요리 설명 수정

            //재료 이미지, 텍스트 수정
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Steak[i];  //재료 이미지 수정

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //재료 텍스트 오브젝트를 가져옴
                ingredient_Text.GetComponent<Text>().text = Steak_ingredient_Text[i];  //재료 이름 수정
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Steak_ingredient_Text[i + 3];  //재료 설명 수정
            }
        }
    }



}
