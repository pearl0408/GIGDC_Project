using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingAnswer : MonoBehaviour
{
    //플레이어가 선택한 답변을 타이핑하고, 엄마의 대사가 타이핑으로 출력되는 클래스
    public GameObject nextPanel;
    public GameObject mom_Message;  //엄마의 대사
    public GameObject player_Message;  //주인공의 대사
    public GameObject playerAnswerPanel; //플레이어 대사 선택 버튼
    public Image BG;    //배경 이미지
    public GameObject breakLine;    //깨진 이미지
    public GameObject bgm;

    public Image mom_Image;   //엄마 이미지
    public Image player_Image;    //주인공 이미지

    Text mom_Text;  //엄마의 텍스트
    Text player_Text;   //플레이어의 텍스트

    private float typingSpeed = 0.2f;  //타이핑 속도
    private float waitSpeed = 2f;  //대화창 텀

    Color currentColor = new Color(1f, 1f, 1f, 1f); //현재 배경 색깔
    Color changeColor;  //바꿀 배경 색깔

    public string[] momAnswerList = { "우리 때는 다 그랬어!" , "나쁘지 않은 대학, 학과면서 뭐가 문제야",
        "살다 보면 다 좋아져", "쉬면 경쟁에서 뒤처지는 거야", "분명 그렇게 가면 실패할걸",
        "나중에 그 일이 싫어지면 어떡할래?", "나중에 우리 탓하지 마라" };  //엄마의 대사 리스트

    public int conflictFlow;   //다툼 흐름

    void Start()
    {
        //mom_Text = mom_Message.gameObject.transform.GetChild(0).gameObejct.GetComponent<Text>();   //텍스트를 가져옴
        //player_Text = player_Message.gameObject.transform.GetChild(0).gameObejct.GetComponent<Text>(); //텍스트를 가져옴
        bgm.GetComponent<AudioSource>().Play();
        conflictFlow = 0;   //다툼 흐름
        breakLine.gameObject.SetActive(false);
        //다툼 시작
        StartCoroutine(momTyping(mom_Message, momAnswerList[conflictFlow]));
    }

    //

    //엄마 메시지 타이핑 함수
    IEnumerator momTyping(GameObject talker_Message, string message)
    {
        waitTermSpeed(conflictFlow);
        yield return new WaitForSeconds(waitSpeed);

        GameObject mom_Message = (GameObject)Instantiate(talker_Message, new Vector2(600f, 1200f), Quaternion.identity);    //말풍선 생성
        mom_Message.gameObject.transform.SetParent(this.gameObject.transform); //현재 오브젝트의 자식 오브젝트로 생성

        mom_Text = mom_Message.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();   //텍스트를 가져옴

        flowSpeed(conflictFlow);    //빠르기 조절
        changeBGColor(conflictFlow);    //배경 색깔 조절

        //메시지 타이핑
        for (int i = 0; i < message.Length; i++)
        {
            mom_Text.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //플레이어 메시지 타이핑 함수
    IEnumerator playerTyping(GameObject talker_Message, string message)
    {
        GameObject player_Message = (GameObject)Instantiate(talker_Message, new Vector2(500f, 1000f), Quaternion.identity);    //말풍선 생성
        player_Message.gameObject.transform.SetParent(this.gameObject.transform); //현재 오브젝트의 자식 오브젝트로 생성

        player_Text = player_Message.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>(); //텍스트를 가져옴

        flowSpeed(conflictFlow);    //빠르기 조절

        //메시지 타이핑
        for (int i = 0; i < message.Length; i++)
        {
            player_Text.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(typingSpeed);
        }

        if (conflictFlow == 7)  //대화가 끝났다면(씬 이동)
        {
            playerAnswerPanel.gameObject.SetActive(false);

            //엄마와 주인공 사이 깨짐
            breakLine.gameObject.SetActive(true);

            //엄마와 주인공 뒤 돌음
            mom_Image.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            player_Image.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);

            nextPanel.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            //타이핑이 끝나면 엄마 메세지 타이핑
            currentColor = BG.color;
            StartCoroutine(momTyping(mom_Message, momAnswerList[conflictFlow]));
        }
    }

    //버튼 선택 함수(버튼 클릭 이벤트에 넣을 것)
    public void selectAnswer()
    {
        string selectText = playerAnswerPanel.gameObject.GetComponent<SelectAnswerConflict>().returnAnswerText();    //플레이어가 선택한 답변을 가져옴

        bool isCorrect = checkCorrectAnswer(selectText); //정답과 일치하는지 확인
        if (isCorrect)  //정답이라면
        {
            StartCoroutine(playerTyping(player_Message, selectText)); //플레이어 답변 타이핑
            conflictFlow++; //대화 흐름 1 증가
        }
        else
        { // 오답이면 진동
            Vibration.Vibrate(100); // 진동
        }
    }

    //플레이어가 선택한 텍스트가 정답과 일치하는지 확인하는 함수
    public bool checkCorrectAnswer(string selectText)
    {
        bool result;

        if (conflictFlow == 0 && selectText == "지금은 시대가 달라요")
        {
            result = true;
        }
        else if (conflictFlow == 1 && selectText == "내가 행복하지 않은 걸요")
        {
            result = true;
        }
        else if (conflictFlow == 2 && selectText == "이렇게 살고 싶지 않아요")
        {
            result = true;
        }
        else if (conflictFlow == 3 && selectText == "운동선수도 매 라운드마다 쉬어요")
        {
            result = true;
        }
        else if (conflictFlow == 4 && selectText == "인생에 어떻게 실패가 없어요")
        {
            result = true;
        }
        else if (conflictFlow == 5 && selectText == "다른 걸 찾으면 되죠")
        {
            result = true;
        }
        else if (conflictFlow == 6 && selectText == "제 인생이니 제가 선택하고 실패하고 이겨낼 거에요")
        {
            result = true;
        }
        else
        {
            result = false;
        }

        return result;
    }

    //타이핑 빠르기 조절
    public void flowSpeed(int flow)
    {
        switch (flow)
        {
            case 0:
                typingSpeed = 0.2f; break;
            case 1:
                typingSpeed = 0.17f; break;
            case 2:
                typingSpeed = 0.15f; break;
            case 3:
                typingSpeed = 0.13f; break;
            case 4:
                typingSpeed = 0.1f; break;
            case 5:
                typingSpeed = 0.08f; break;
            case 6:
                typingSpeed = 0.05f; break;
        }
    }


    //타이핑 빠르기 조절
    public void waitTermSpeed(int flow)
    {
        switch (flow)
        {
            case 0:
                waitSpeed = 2f; break;
            case 1:
                waitSpeed = 2f; break;
            case 2:
                waitSpeed = 1.8f; break;
            case 3:
                waitSpeed = 1.8f; break;
            case 4:
                waitSpeed = 1.5f; break;
            case 5:
                waitSpeed = 1.3f; break;
            case 6:
                waitSpeed = 1f; break;
        }
    }

    //배경 색깔 조절
    public void changeBGColor(int flow)
    {
        switch (flow)
        {
            case 0:
                BG.color = Color.white; break;
            case 1:
                changeColor = new Color(1f, 0.9f, 0.9f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 2:
                changeColor = new Color(1f, 0.8f, 0.8f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 3:
                changeColor = new Color(1f, 0.65f, 0.65f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 4:
                changeColor = new Color(1f, 0.5f, 0.5f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 5:
                changeColor = new Color(1f, 0.25f, 0.25f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 6:
                changeColor = new Color(1f, 0f, 0f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
        }
    }
}
