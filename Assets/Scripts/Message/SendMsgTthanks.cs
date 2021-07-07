using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTthanks : MonoBehaviour
{
    public GameObject myMsg, yourMsg; // 메세지 변수
    public Button copyBtn,sendBtn; // 복사하기 버튼 
    public GameObject alarmMessage;  //메시지 패널

    public Text m_TypingText; // 타이핑 메세지
    public string m_Message; // 전송 메세지
    public float m_Speed = 0.2f; // 타이핑 속도
    public Text CopyBtnTxt; // 복사한 거 번호
    public Text inputTxt; // text안 초기화 

    int waitingTime = 2;
    float timer = 0;

    // 복사 - 붙여넣기 패널이 켜지고(o)
    // 붙여넣기가 완료되면(o)
    // 번호 텍스트가 바뀌고 (0)

    // 나의 메세지가 타이핑 되고
    // 전송버튼을 누르면
    // 학생회장에게 문자가 전송이되고
    // 학생회장에게 문자를 받는다(3분후) - realTime

    // Start is called before the first frame update
    void Start()
    {
        waitingTime = 2;
        timer = 0;
        m_Message = "안녕하세요!매하일기 . . .";

        // 버튼 클릭하기
        copyBtn.onClick.AddListener(clickedCopyBtn);
      
    }

    void OnEnable() //씬이 활성화 될 때마다 확인
    {
        ReceiveAnswer();
    }

    // 복붙하기 클릭할 시 변화
    public void clickedCopyBtn()
    {
        Vibration.Vibrate(100); // 진동함수
        CopyBtnTxt.text = "010-0000-0000";
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
    }

    // 나의 메세지가 타이핑 되고 
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(showSendMsg());
    }

    // 전송 버튼이 눌리면 안에를 초기화 하고
    IEnumerator showSendMsg()
    {
        inputTxt.text = "안녕하세요!매하일기 . . .";
        sendBtn.onClick.AddListener(clikedSendBtn);

        yield return new WaitForSeconds(1.0f);

    }

    // 전송 메세지를 보여주고 
    public void clikedSendBtn()
    {
        Vibration.Vibrate(100); // 진동함수
        inputTxt.text = "";
        myMsg.SetActive(true);

        // 3분 대기 함수
        Invoke("showYourMsg", 60 * 1);

    }

    public void showYourMsg()
    {
        alarmMessage.GetComponent<StartAlarmTalk>().alarmTalk();
        yourMsg.SetActive(true);  
    }

    //학생회장 문자를 받고 다음 스크립트로 넘어가는 함수
    public void ReceiveAnswer()
    {
        if (this.gameObject.activeSelf == true && yourMsg.gameObject.activeSelf == true)    //메시지 어플이 활성화되어있고 답장도 왔다면
        {
            StartCoroutine("WaitAndSceneChange");
        }
    }

    IEnumerator WaitAndSceneChange()
    {
        yield return new WaitForSeconds(5f);   //5초뒤
        GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartBeforeOneWeekScene(); //씬 전환
    }
}
