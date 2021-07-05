using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Unlock : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Vector2 startPosition;//슬라이드 핸들러 시작 위치
    public GameObject unlockPanel;//잠금화면 패널
    GameObject alarmTalkImg;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;//시작 위치
        unlockPanel = GameObject.Find("Panel_Lock");//패널 지정
        alarmTalkImg = GameObject.Find("alarmTalk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //뒤로 슬라이더 핸들러가 왼쪽으로 가지 않을 때
        if(eventData.position.x>startPosition.x)
        {
            transform.position = new Vector2(eventData.position.x, transform.position.y);//마우스를 따라 움직이는 핸들러
        }
        //잠금 해제
        if(eventData.position.x>770)
        {
            alarmTalkImg.GetComponent<StartAlarmTalk>().alarmTalk();
            unlockPanel.SetActive(false);//패널 끄기
            Vibration.Vibrate(100); // 진동
        }
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(eventData.position.x<770)
        {          
            StartCoroutine(reposition());//돌아가기
        }
    }

    //첫 위치로 돌아가기
    IEnumerator reposition()
    {
        while(transform.position.x>startPosition.x)
        {
            Debug.Log(transform.position.x);
            transform.Translate(-20, 0, 0);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }
    }

    /*public void alarmTalk()
    {
        StartCoroutine(downAndup());
    }*/

    /*IEnumerator downAndup()
    {
        yield return new WaitForSeconds(1.0f);

        while (transform.position.y > 954)
        {
            alarmTalkImg.transform.Translate(0, -50, 0);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        yield return new WaitForSeconds(2.0f);

        while (transform.position.y < 897)
        {
            alarmTalkImg.transform.Translate(0, 50, 0);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }
    }*/
}
