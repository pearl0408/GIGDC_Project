using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveChapter : MonoBehaviour
{
    //챕터에 저장 기록을 적용하는 함수

    public Button[] chapterList;    //챕터 실행시키는 버튼
    public Image[] checkLine;   //이미 완료한 챕터에 표시할 선

    void OnEnable()     //활성화 될 때마다
    {
        int save = PlayerPrefs.GetInt("SaveDay", 1);

        chapterList[save].gameObject.SetActive(true);   //마지막으로 한 챕터의 다음 챕터 시작되게

        for (int i = 0; i < save; i++)
        {
            chapterList[i].gameObject.SetActive(true);
            checkLine[i].gameObject.SetActive(true);
        }
    }
}
