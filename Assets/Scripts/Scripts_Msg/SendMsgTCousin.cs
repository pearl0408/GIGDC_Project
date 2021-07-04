using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTCousin : MonoBehaviour
{
    public Button touchPanel; // 화면 터치 영역
    public int Cnt; // 화면 터치 횟수 
    public GameObject Msg1, Msg2, Msg3; // 메세지

    // Start is called before the first frame update
    void Start()
    {
        Cnt = 0; // 횟수 0번으로 시작
        touchPanel.onClick.AddListener(touchOnce); // 터치 작동하게 하는 함수
    }

    IEnumerator touchCnt()
    {
        Cnt++;

        if(Cnt == 1)
         {
            Msg1.SetActive(true);
        }
        if (Cnt == 2)
        {
            Msg2.SetActive(true);
         }
        if (Cnt == 3)
        {
            Msg3.SetActive(true);
        }
        if (Cnt == 4)
        {
            Destroy(gameObject);
        }
        

       yield return new WaitForSeconds(0.01f); //0.01초 딜레이

    }

    public void touchOnce()
    {
        StartCoroutine(touchCnt());
    }

}
