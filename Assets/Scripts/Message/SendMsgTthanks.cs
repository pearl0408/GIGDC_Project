using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTthanks : MonoBehaviour
{
    public GameObject myMsg, yourMsg; // �޼��� ����
    public Button copyBtn,sendBtn; // �����ϱ� ��ư 
    public GameObject alarmMessage;  //�޽��� �г�

    public Text m_TypingText; // Ÿ���� �޼���
    public string m_Message; // ���� �޼���
    public float m_Speed = 0.2f; // Ÿ���� �ӵ�
    public Text CopyBtnTxt; // ������ �� ��ȣ
    public Text inputTxt; // text�� �ʱ�ȭ 

    int waitingTime = 2;
    float timer = 0;

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

        // ��ư Ŭ���ϱ�
        copyBtn.onClick.AddListener(clickedCopyBtn);
      
    }

    void OnEnable() //���� Ȱ��ȭ �� ������ Ȯ��
    {
        ReceiveAnswer();
    }

    // �����ϱ� Ŭ���� �� ��ȭ
    public void clickedCopyBtn()
    {
        Vibration.Vibrate(100); // �����Լ�
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
        Vibration.Vibrate(100); // �����Լ�
        inputTxt.text = "";
        myMsg.SetActive(true);

        // 3�� ��� �Լ�
        Invoke("showYourMsg", 60 * 1);

    }

    public void showYourMsg()
    {
        alarmMessage.GetComponent<StartAlarmTalk>().alarmTalk();
        yourMsg.SetActive(true);  
    }

    //�л�ȸ�� ���ڸ� �ް� ���� ��ũ��Ʈ�� �Ѿ�� �Լ�
    public void ReceiveAnswer()
    {
        if (this.gameObject.activeSelf == true && yourMsg.gameObject.activeSelf == true)    //�޽��� ������ Ȱ��ȭ�Ǿ��ְ� ���嵵 �Դٸ�
        {
            StartCoroutine("WaitAndSceneChange");
        }
    }

    IEnumerator WaitAndSceneChange()
    {
        yield return new WaitForSeconds(5f);   //5�ʵ�
        GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartBeforeOneWeekScene(); //�� ��ȯ
    }
}
