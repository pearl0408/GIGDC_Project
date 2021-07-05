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

        switch(randomInt)
        {
            case 0:
                GameManager.instance.selectBook = "bread";  break;
            case 1:
                GameManager.instance.selectBook = "cat"; break;
            case 2:
                GameManager.instance.selectBook = "chicken"; break;
            case 3:
                GameManager.instance.selectBook = "dinner"; break;
        }
    }
}
