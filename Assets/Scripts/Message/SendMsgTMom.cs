using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTMom : MonoBehaviour
{
    public Text m_TypingText; // 타이핑 메세지
    public string m_Message; // 전송 메세지
    public float m_Speed = 0.2f; // 타이핑 속도

    public Button sendBtn;  // 전송 버튼
    public GameObject showMsg; // 화면상 메세지
    public GameObject blockMsg; // 뒤로가기 막는 패널

    // Start is called before the first frame update
    void Start()
    {
        m_Message = "오늘 집에 갈게요";
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
    }

    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(showSendMsg());
    }

    IEnumerator showSendMsg()
    {
        sendBtn.onClick.AddListener(clikedBtn);
        yield return new WaitForSeconds(1.0f);
    }

    public void clikedBtn()
    {
        showMsg.SetActive(true);
        blockMsg.SetActive(false);
    }
}
