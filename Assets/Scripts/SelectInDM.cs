using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectInDM : MonoBehaviour
{
    int Cnt; // 화면 터치 횟수 
    public Button tocuhPanel; // 화면 터치 영역
    public GameObject Msg1, Msg2, Msg3, Msg4; // 메세지
    public GameObject selectPanel; // 위치 선택 영역
    public Button btn1, btn2, btn3; // 위치 선택 버튼 
    public GameObject Msg3Txt; // 정답 메세지
    public GameObject blockPanel; // 퀴즈 패널 외 영역 터치를 막기 위한 방어 패널

    // Start is called before the first frame update
    void Start()
    {
        Cnt = 0;
        tocuhPanel.onClick.AddListener(touchOnce); // 터치 작동하게 하는 함수
    }

    // 터치 코루틴 작동 시작
    public void touchOnce()
    {
        Vibration.Vibrate(100); // 진동 함수
        StartCoroutine(touchCnt());
    }

    IEnumerator touchCnt()
    {
        Cnt++;

        // msg1 보이기
        if (Cnt == 1)
        {
            Msg1.SetActive(true);
        }
        // msg2 보이기
        if (Cnt == 2)
        {
            Msg2.SetActive(true);
        }
        // msg3 보이기
        if (Cnt == 3)
        {
            Msg3.SetActive(true);
        }
        // 퀴즈 패널 보이기 
        if (Cnt == 4)
        {
            //블록 패널 보이기 
            blockPanel.SetActive(true);
            // 퀴즈 코루틴 시작 
            selectPanel.SetActive(true);
            StartCoroutine(showQuizPanel());

        }
      

        yield return new WaitForSeconds(0.01f); //0.01초 딜레이

    }

    // 퀴즈 코루틴 함수 
    IEnumerator showQuizPanel()
    {
        // 퀴즈 오답 시
        btn1.onClick.AddListener(wrongClicked);

        btn3.onClick.AddListener(wrongClicked);

        // 퀴즈 정답 시 
        btn2.onClick.AddListener(correctClicked);

        yield return new WaitForSeconds(0.01f); //0.01초 딜레이
    }

    // 오답 클릭 시 버튼 이벤트
    public void wrongClicked()
    {
        Vibration.Vibrate(200); // 진동 함수
    }

    // 정답 클릭 시 버튼 이벤트 
    public void correctClicked()
    {
        Object.Destroy(blockPanel);//  방어 패널 없애기 
        Object.Destroy(selectPanel);// 퀴즈 패널 없애기
        Msg3Txt.SetActive(true); // 정답 메세지 보여주기

        StartCoroutine(showFinalMsg());
  
    }

    IEnumerator showFinalMsg()
    {
        yield return new WaitForSeconds(1f); //3초 딜레이
        Msg4.SetActive(true);


        yield return new WaitForSeconds(2f); //3초 딜레이
        Destroy(gameObject);  // touchPanel 없애기
    }

}
