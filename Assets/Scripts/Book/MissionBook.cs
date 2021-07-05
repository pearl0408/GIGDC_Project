using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBook : MonoBehaviour
{
    //미션 도서 스프라이트를 변경하는 스크립트

    public Sprite[] missionBookList;    //미션 도서 리스트
    
    void Start()
    {
        int randomInt = Random.Range(0, missionBookList.Length);    //랜덤 인덱스 생성

        this.gameObject.GetComponent<Image>().sprite = missionBookList[randomInt];  //랜덤 인덱스의 스프라이트로 변경

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
