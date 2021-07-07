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
    public GameObject popUpMsg; // 여행 알림 메시지

    public Text m_TypingText; // 타이핑 메세지
    public string m_Message; // 전송 메세지
    public float m_Speed = 0.2f; // 타이핑 속도

    // Start is called before the first frame update
    void Start()
    {
        Cnt = 0;
        m_Message = "응! 괜찮아.고마워.";
        touchPanel.onClick.AddListener(touchOnce);
    }


    // 친구 메세지 확인 함수(최초 클릭시 확인 가능)
    public void touchOnce()
    {
        Cnt++;

        if (Cnt == 1)
        {
            Msg1.SetActive(true); // 친구 메세지 확인
        }

        if (Cnt == 2)
        { 
            StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
            Destroy(delPanel);
        }
    }


    // 타이핑 출력 함수 
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(showSendMsg());
    }

    // 전송 버튼 클릭 함수 
    IEnumerator showSendMsg()
    {
        sendBtn.onClick.AddListener(clikedBtn);

        yield return new WaitForSeconds(1.0f);

    }

    // 전송 메세지 화면에 보여주는 함수 
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
