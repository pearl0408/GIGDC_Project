using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Unlock : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Vector2 startPosition;//�����̵� �ڵ鷯 ���� ��ġ
    public GameObject unlockPanel;//���ȭ�� �г�

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;//���� ��ġ
        unlockPanel = GameObject.Find("Panel_Lock");//�г� ����
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
            unlockPanel.SetActive(false);//�г� ����
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
}
