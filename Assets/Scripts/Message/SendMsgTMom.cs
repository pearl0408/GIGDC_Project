using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTMom : MonoBehaviour
{
    public Text m_TypingText; // Ÿ���� �޼���
    public string m_Message; // ���� �޼���
    public float m_Speed = 0.2f; // Ÿ���� �ӵ�

    public Button sendBtn;  // ���� ��ư
    public GameObject showMsg; // ȭ��� �޼���
    public GameObject blockMsg; // �ڷΰ��� ���� �г�

    // Start is called before the first frame update
    void Start()
    {
        m_Message = "���� ���� ���Կ�";
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
