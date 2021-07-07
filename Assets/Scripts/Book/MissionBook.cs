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
                PlayerPrefs.SetString("SelectBook", "bread");
            case 1:
                GameManager.instance.selectBook = "cat"; break;
                PlayerPrefs.SetString("SelectBook", "cat");
            case 2:
                GameManager.instance.selectBook = "chicken"; break;
                PlayerPrefs.SetString("SelectBook", "chicken");
            case 3:
                GameManager.instance.selectBook = "dinner"; break;
                PlayerPrefs.SetString("SelectBook", "dinner");
        }
    }

    //�̼Ǻ� ��ư �̺�Ʈ
    public void SelectMissionBook()
    {
        //���� ������ �̵�
        GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartAnimationDay2Scene();
    }
}
