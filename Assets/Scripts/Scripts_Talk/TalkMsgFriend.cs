using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkMsgFriend : MonoBehaviour
{
    public Text m_TypingText; // 타이핑 메세지
    public string m_Message; // 전송 메세지
    public float m_Speed = 0.2f; // 타이핑 속도

    public GameObject myMsg1; // 나의 메세지("고맙다고 인사하고 싶어")
    public GameObject yourMsg1; // 친구의 답장("학생회장 번호야")
    public GameObject toastMsg; // 토스트 메세지

    Color c, tc; //토스트메세지의 배경과 택스트 칼라

    public Button sendBtn; // 전송 버튼 
    public Button copyMsgBtn; // 친구 답장을 복사하기 위한 버튼

    public GameObject activeMsg; // 메세지 기능 활성화

    // 1.친구 A와의 카톡을 들어가면 자동으로 타이핑 입력됨(0)
    // 2.전송 버튼을 누르면 메시지가 전송됨(0)
    // 3.친구의 답장을 누르면 메시지가 복사됨(토스트 메시지 나타남)
    // 4. 메시지 앱애서 받는 사람 옆의 칸을 누르면 복사한 내용 입력됨 
    // 5. 복사된 내용이 없다면 복사된 내용이 없다는 토스트 메시지가 나타남
    // 6. 번호가 복사되면 입력창에 장문의 문자가 쓰여짐(한 줄만 보임)
    // 7. 전송 버튼을 누르면 메시지가 전송되고, 실제 시간 3분 뒤에 답장이 옴(타이핑 효과)

    // Start is called before the first frame update
    void Start()
    {
        m_Message = "고맙다는 인사를 하고 싶어";
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
        //StartCoroutine(Typing(m_TypingText,"고맙다는 인사를 하고 싶어.",m_Speed));
    }

    // 친구에게 감사인사 전하기 
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(showSendMsg());
    }

    // 전송 버튼 대기 함수 
    IEnumerator showSendMsg()
    {
        sendBtn.onClick.AddListener(clikedBtn);

        yield return new WaitForSeconds(1.0f);

    }

    // 전송 버튼 클릭 함수 -> 친구의 메세지를 보여줌
    public void clikedBtn()
    {
        m_TypingText.text = "";
        myMsg1.SetActive(true);

        StartCoroutine(showFreindMsg1());
    }

    // 친구의 메세지를 보여줌 
    IEnumerator showFreindMsg1()
    {
        yield return new WaitForSeconds(3.0f);

        yourMsg1.SetActive(true);

        //친구 메세지 누르면 복사하게 만든다
        copyMsgBtn.onClick.AddListener(clikedFriendMsg1);
        //yourMsg1.GetComponent<Button>().onClick.AddListener(clikedFriendMsg1);
    }

    // 친구의 답장을 클릭했을 때의 토스트 메세지 받아오기 
    public void clikedFriendMsg1()
    {
        StartCoroutine(Toast());

    }

    // 친구의 답장을 클릭함 ->  토스트 메세지 띄우기 
    IEnumerator Toast()
    {
        yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        toastMsg.SetActive(true);
        StartCoroutine(AcitveDel());
    }

    //페이드 아웃
    IEnumerator AcitveDel()
    {
        yield return new WaitForSeconds(2.0f);
        toastMsg.SetActive(false);

        activeMsg.SetActive(true);

        //StopAllCoroutines();

    }





}
