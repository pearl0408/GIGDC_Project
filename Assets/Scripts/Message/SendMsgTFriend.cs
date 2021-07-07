using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTFriend : MonoBehaviour
{
    public Button touchPanel,sendBtn;
    public GameObject delPanel;
    public int Cnt;
    public GameObject Msg1, Msg2;
    public GameObject popUpMsg; // ���� �˸� �޽���

    public Text m_TypingText; // Ÿ���� �޼���
    public string m_Message; // ���� �޼���
    public float m_Speed = 0.2f; // Ÿ���� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        Cnt = 0;
        m_Message = "��! ������.����.";
        touchPanel.onClick.AddListener(touchOnce);
    }


    // ģ�� �޼��� Ȯ�� �Լ�(���� Ŭ���� Ȯ�� ����)
    public void touchOnce()
    {
        Cnt++;

        if (Cnt == 1)
        {
            Msg1.SetActive(true); // ģ�� �޼��� Ȯ��
        }

        if (Cnt == 2)
        { 
            StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
            Destroy(delPanel);
        }
    }


    // Ÿ���� ��� �Լ� 
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(showSendMsg());
    }

    // ���� ��ư Ŭ�� �Լ� 
    IEnumerator showSendMsg()
    {
        sendBtn.onClick.AddListener(clikedBtn);

        yield return new WaitForSeconds(1.0f);

    }

    // ���� �޼��� ȭ�鿡 �����ִ� �Լ� 
    public void clikedBtn()
    {
        Msg2.SetActive(true);
       
        StartCoroutine(showTravelPopUp());
    }

    IEnumerator showTravelPopUp()
    {
        yield return new WaitForSeconds(2.0f);
        popUpMsg.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartAnimationInstaScene();
    }
}
