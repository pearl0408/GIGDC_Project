using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTthanks : MonoBehaviour
{
    public GameObject copyArea; // ���� �г�
    public GameObject myMsg, yourMsg; // �޼��� ����
    public Button copyBtn,sendBtn; // �����ϱ� ��ư 

    public Text m_TypingText; // Ÿ���� �޼���
    public string m_Message; // ���� �޼���
    public float m_Speed = 0.2f; // Ÿ���� �ӵ�
    public Text CopyBtnTxt; // ������ �� ��ȣ
    public Text inputTxt; // text�� �ʱ�ȭ 


    int waitingTime;
    float timer;

    // ���� - �ٿ��ֱ� �г��� ������(o)
    // �ٿ��ֱⰡ �Ϸ�Ǹ�(o)
    // ��ȣ �ؽ�Ʈ�� �ٲ�� (0)

    // ���� �޼����� Ÿ���� �ǰ�
    // ���۹�ư�� ������
    // �л�ȸ�忡�� ���ڰ� �����̵ǰ�
    // �л�ȸ�忡�� ���ڸ� �޴´�(3����) - realTime

    // Start is called before the first frame update
    void Start()
    {
        waitingTime = 2;
        timer = 0;
        m_Message = "�ȳ��ϼ���!�����ϱ� . . .";

        // Ȱ��ȭ �Ǿ� �ִٸ�
        if (copyArea.activeSelf == true)
        {
            // ��ư Ŭ���ϱ�
            copyBtn.onClick.AddListener(clickedCopyBtn);
           
        }
    }

    // �����ϱ� Ŭ���� �� ��ȭ
    public void clickedCopyBtn()
    {
        CopyBtnTxt.text = "010-0000-0000";
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
    }

    // ���� �޼����� Ÿ���� �ǰ� 
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(showSendMsg());
    }

    // ���� ��ư�� ������ �ȿ��� �ʱ�ȭ �ϰ�
    IEnumerator showSendMsg()
    {
        inputTxt.text = "�ȳ��ϼ���!�����ϱ� . . .";
        sendBtn.onClick.AddListener(clikedSendBtn);

        yield return new WaitForSeconds(1.0f);

    }

    // ���� �޼����� �����ְ� 
    public void clikedSendBtn()
    {
        inputTxt.text = "";
        myMsg.SetActive(true);

        // 3�� ��� �Լ�
        Invoke("showYourMsg", 10);

    }

    public void showYourMsg()
    {       
        yourMsg.SetActive(true);  
    }

}