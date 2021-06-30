using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchWriter : MonoBehaviour
{
    //작가 이름이 흩어져있는 스크립트
    public char[] writerName = { '백', '희', '나', '이', '솝', '안', '데', '르', '센' }; //작가 이름
    public Button charButton;   //생성할 글자 버튼

    private float XPosition;    //랜덤 X 좌표(-300 ~ 300 사이)
    private float YPosition;    //랜덤 Y 좌표(-250 ~ 250 사이)

    public Text text_Keyword;   //키워드 입력창

    //게임이 시작하면
    void Start()
    {
        ResetButton();  //버튼 생성 및 검색어 초기화
    }

    //검색 버튼을 누를 때마다 검색어와 단어 위치가 초기화
    public void ResetButton()
    {
        text_Keyword.text = "";  //검색창 초기화

        //글자 버튼들이 랜덤 위치에 생성됨
        for (int i = 0; i < writerName.Length; i++)
        {
            XPosition = Random.Range(200, 900);    //X 좌표 생성
            YPosition = Random.Range(350, 850);    //Y 좌표 생성

            //버튼 생성
            Button Btn_WriterName = (Button)Instantiate(charButton, new Vector2(XPosition, YPosition), Quaternion.identity);   //버튼 생성

            GameObject myText = Btn_WriterName.gameObject.transform.GetChild(0).gameObject;  //버튼의 텍스트 오브젝트를 가져옴
            myText.GetComponent<Text>().text = writerName[i].ToString();  //텍스트 변경

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
}
