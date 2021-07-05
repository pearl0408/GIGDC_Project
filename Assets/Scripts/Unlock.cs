using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Unlock : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Vector2 startPosition;//�����̵� �ڵ鷯 ���� ��ġ
    public GameObject unlockPanel;//���ȭ�� �г�
    GameObject alarmTalkImg;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;//���� ��ġ
        unlockPanel = GameObject.Find("Panel_Lock");//�г� ����
        alarmTalkImg = GameObject.Find("alarmTalk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //�ڷ� �����̴� �ڵ鷯�� �������� ���� ���� ��
        if(eventData.position.x>startPosition.x)
        {
            transform.position = new Vector2(eventData.position.x, transform.position.y);//���콺�� ���� �����̴� �ڵ鷯
        }
        //��� ����
        if(eventData.position.x>770)
        {
            alarmTalkImg.GetComponent<StartAlarmTalk>().alarmTalk();
            unlockPanel.SetActive(false);//�г� ����
            Vibration.Vibrate(100); // ����
        }
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(eventData.position.x<770)
        {          
            StartCoroutine(reposition());//���ư���
        }
    }

    //ù ��ġ�� ���ư���
    IEnumerator reposition()
    {
        while(transform.position.x>startPosition.x)
        {
            Debug.Log(transform.position.x);
            transform.Translate(-20, 0, 0);
            yield return new WaitForSeconds(0.01f); //0.01�� ������
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
            yield return new WaitForSeconds(0.01f); //0.01�� ������
        }

        yield return new WaitForSeconds(2.0f);

        while (transform.position.y < 897)
        {
            alarmTalkImg.transform.Translate(0, 50, 0);
            yield return new WaitForSeconds(0.01f); //0.01�� ������
        }
    }*/
}
