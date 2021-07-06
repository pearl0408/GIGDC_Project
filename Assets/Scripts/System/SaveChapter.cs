using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChapter : MonoBehaviour
{
   
    //챕터를 저장하는 함수(Day 하나가 끝날 때마다 실행)
    public void SaveThisChapter(int chapterIndex)
    {
        PlayerPrefs.SetInt("SaveChapter", chapterIndex);
    }

    //저장된 챕터를 반환하는 함수
    public int LoadSaveChapter()
    {
        return PlayerPrefs.GetInt("SaveChapter", 1);
    }
}
