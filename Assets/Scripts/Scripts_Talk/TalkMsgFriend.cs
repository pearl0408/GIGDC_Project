using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkMsgFriend : MonoBehaviour
{
    public Text m_TypingText; // Ÿ���� �޼���
    public string m_Message; // ���� �޼���
    public float m_Speed = 0.2f; // Ÿ���� �ӵ�

    public GameObject myMsg1; // ���� �޼���("���ٰ� �λ��ϰ� �;�")
    public GameObject yourMsg1; // ģ���� ����("�л�ȸ�� ��ȣ��")
    public GameObject toastMsg; // �佺Ʈ �޼���

    Color c, tc; //�佺Ʈ�޼����� ���� �ý�Ʈ Į��

    public Button sendBtn; // ���� ��ư 
    public Button copyMsgBtn; // ģ�� ������ �����ϱ� ���� ��ư

    public GameObject activeMsg; // �޼��� ��� Ȱ��ȭ

    // 1.ģ�� A���� ī���� ���� �ڵ����� Ÿ���� �Էµ�(0)
    // 2.���� ��ư�� ������ �޽����� ���۵�(0)
    // 3.ģ���� ������ ������ �޽����� �����(�佺Ʈ �޽��� ��Ÿ��)
    // 4. �޽��� �۾ּ� �޴� ��� ���� ĭ�� ������ ������ ���� �Էµ� 
    // 5. ����� ������ ���ٸ� ����� ������ ���ٴ� �佺Ʈ �޽����� ��Ÿ��
    // 6. ��ȣ�� ����Ǹ� �Է�â�� �幮�� ���ڰ� ������(�� �ٸ� ����)
    // 7. ���� ��ư�� ������ �޽����� ���۵ǰ�, ���� �ð� 3�� �ڿ� ������ ��(Ÿ���� ȿ��)

    // Start is called before the first frame update
    void Start()
    {
        m_Message = "���ٴ� �λ縦 �ϰ� �;�";
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
        //StartCoroutine(Typing(m_TypingText,"���ٴ� �λ縦 �ϰ� �;�.",m_Speed));
    }

    // ģ������ �����λ� ���ϱ� 
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(showSendMsg());
    }

    // ���� ��ư ��� �Լ� 
    IEnumerator showSendMsg()
    {
        sendBtn.onClick.AddListener(clikedBtn);

        yield return new WaitForSeconds(1.0f);

    }

    // ���� ��ư Ŭ�� �Լ� -> ģ���� �޼����� ������
    public void clikedBtn()
    {
        m_TypingText.text = "";
        myMsg1.SetActive(true);

        StartCoroutine(showFreindMsg1());
    }

    // ģ���� �޼����� ������ 
    IEnumerator showFreindMsg1()
    {
        yield return new WaitForSeconds(3.0f);

        yourMsg1.SetActive(true);

        //ģ�� �޼��� ������ �����ϰ� �����
        copyMsgBtn.onClick.AddListener(clikedFriendMsg1);
        //yourMsg1.GetComponent<Button>().onClick.AddListener(clikedFriendMsg1);
    }

    // ģ���� ������ Ŭ������ ���� �佺Ʈ �޼��� �޾ƿ��� 
    public void clikedFriendMsg1()
    {
        StartCoroutine(Toast());

    }

    // ģ���� ������ Ŭ���� ->  �佺Ʈ �޼��� ���� 
    IEnumerator Toast()
    {
        yield return new WaitForSeconds(0.01f); //0.01�� ������
        toastMsg.SetActive(true);
        StartCoroutine(AcitveDel());
    }

    //���̵� �ƿ�
    IEnumerator AcitveDel()
    {
        yield return new WaitForSeconds(2.0f);
        toastMsg.SetActive(false);

        activeMsg.SetActive(true);

        //StopAllCoroutines();

    }





}
