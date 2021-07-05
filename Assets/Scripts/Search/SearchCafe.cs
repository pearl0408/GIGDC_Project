using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchCafe : MonoBehaviour
{
    //카페 추천 텍스트가 흩어져서 움직이는 스크립트
    public char[] moveKeyword = { '카', '페', '추', '천', '아', '메', '리', '카', '노', '라', '떼'};
    public Button charButton;   //생성할 글자 버튼

    private float XPosition;    //랜덤 X 좌표(200 ~ 900 사이)
    private float YPosition;    //랜덤 Y 좌표(350 ~ 850 사이)

    public Text text_Keyword;   //키워드 입력창

    public GameObject searchResultPanel;    //검색 결과 패널


    //게임이 시작하면
    void Start()
    {
        ResetButton();  //버튼 생성 및 검색어 초기화
    }

    //검색 버튼을 누를 때마다 검색어와 단어 위치가 초기화
    public void ResetButton()
    {
        //모든 자식 오브젝트 삭제
        var childButton = this.GetComponentsInChildren<Transform>();   //자식 오브젝트들을 가져옴
        foreach (var iter in childButton)
        {
            if (iter != this.transform)
            {
                Destroy(iter.gameObject);   //부모 오브젝트가 아니라면 게임 오브젝트 삭제
            }
        }

        text_Keyword.text = "";  //검색창 초기화

        //글자 버튼들이 랜덤 위치에 생성됨
        for (int i = 0; i < moveKeyword.Length; i++)
        {
            XPosition = Random.Range(200, 900);    //X 좌표 생성
            YPosition = Random.Range(350, 850);    //Y 좌표 생성

            //버튼 생성
            Button Btn_WriterName = (Button)Instantiate(charButton, new Vector2(XPosition, YPosition), Quaternion.identity);   //버튼 생성

            GameObject myText = Btn_WriterName.gameObject.transform.GetChild(0).gameObject;  //버튼의 텍스트 오브젝트를 가져옴
            myText.GetComponent<Text>().text = moveKeyword[i].ToString();  //텍스트 변경

            Btn_WriterName.gameObject.transform.SetParent(this.gameObject.transform); //현재 오브젝트의 자식 오브젝트로 생성
            Btn_WriterName.onClick.AddListener(() => TypingButtonText(myText)); //버튼 클릭 이벤트 추가
        }
    }

    //버튼을 누르면 버튼 텍스트 입력됨
    public void TypingButtonText(GameObject myText)
    {
        string text = myText.GetComponent<Text>().text;
        text_Keyword.text += text;    //검색어 텍스트에 자신의 텍스트를 추가함
    }

    //검색 버튼을 누르면 검색한 이름이 맞는지 확인하고 동작하는 함수(버튼 이벤트)
    public void CheckKeyword()
    {
        string inputText = text_Keyword.text;   //입력한 글자를 가져옴
        if (inputText == "카페추천")   //만약 올바르게 입력했다면
        {
            text_Keyword.text = "";  //텍스트 삭제
            searchResultPanel.gameObject.SetActive(true);   //검색 결과창 활성화
        }
        else    //만약 검색 결과가 틀리다면
        {
            ResetButton();  //입력창 및 글자 위치 초기화
        }
    }
}
