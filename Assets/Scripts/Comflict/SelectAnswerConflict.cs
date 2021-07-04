using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnswerConflict : MonoBehaviour
{
    //엄마와 다툴때 답변을 선택하는 클래스

    string[] playerAnswerList = { "지금은 시대가 달라요", "내가 행복하지 않은 걸요",
        "이렇게 살고 싶지 않아요", "운동선수도 매 라운드마다 쉬어요", "인생에 어떻게 실패가 없어요",
        "다른 걸 찾으면 되죠", "제 인생이니 제가 선택하고 실패하고 이겨낼 거에요"};  //주인공 답변 배열 선언

    public int currentAnswerIndex; //현재 선택된 텍스트 번호
    public Text answerText; //플레이어 답변 텍스트

    void Start()   
    {
        Shuffle(playerAnswerList);  //씬이 시작되면 대사 순서를 섞음

        //선택 가능한 대사를 보여줌
        currentAnswerIndex = 0;
        ChangeShowAnswer();

    }

    //다음 대사로 넘어가는 버튼 이벤트
    public void NextAnswer()
    {
        if (currentAnswerIndex == 6)    //만약 다음 답변이 없다면
        {
            currentAnswerIndex = 0; //제일 처음으로 이동
        }
        else //아니라면
        {
            currentAnswerIndex++;   //다음 답변 보여줌
        }

        ChangeShowAnswer(); //보여주는 답변 변경
    }

    //이전 대사로 돌아가는 버튼 이벤트
    public void BeforeAnswer()
    {
        if (currentAnswerIndex == 0)    //만약 이전 답변이 없다면
        {
            currentAnswerIndex = 6; //제일 끝으로 이동
        }
        else //아니라면
        {
            currentAnswerIndex--;   //이전 답변 보여줌
        }

        ChangeShowAnswer(); //보여주는 답변 결정
    }

    //현재 답변 번호에 맞춰 답변 텍스트를 변경하는 함수
    public void ChangeShowAnswer()
    {
        answerText.text = playerAnswerList[currentAnswerIndex]; //텍스트를 변경함
    }

    //선택한 답변 텍스트를 반환하는 함수
    public string returnAnswerText()
    {
        return playerAnswerList[currentAnswerIndex];
    }

    //셔플 함수
    void Shuffle(string[] stringArray)
    {
        int random1, random2;   //인덱스
        string tempString; //임시 버튼

        for (int i = 0; i < stringArray.Length; i++)
        {
            random1 = Random.Range(0, stringArray.Length);    //랜덤 인덱스 생성
            random2 = Random.Range(0, stringArray.Length);    //랜덤 인덱스 생성

            tempString = stringArray[random1];    //임시 버튼 저장
            stringArray[random1] = stringArray[random2];  //버튼 변경
            stringArray[random2] = tempString;    //임시 버튼 변경
        }
    }
}
