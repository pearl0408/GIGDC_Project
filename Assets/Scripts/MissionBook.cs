using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBook : MonoBehaviour
{
    //�̼� ���� ��������Ʈ�� �����ϴ� ��ũ��Ʈ

    public Sprite[] missionBookList;    //�̼� ���� ����Ʈ
    
    void Start()
    {
        int randomInt = Random.Range(0, missionBookList.Length);    //���� �ε��� ����

        this.gameObject.GetComponent<Image>().sprite = missionBookList[randomInt];  //���� �ε����� ��������Ʈ�� ����
    }
}
