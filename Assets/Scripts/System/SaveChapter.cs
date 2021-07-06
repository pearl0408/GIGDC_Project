using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChapter : MonoBehaviour
{
   
    //é�͸� �����ϴ� �Լ�(Day �ϳ��� ���� ������ ����)
    public void SaveThisChapter(int chapterIndex)
    {
        PlayerPrefs.SetInt("SaveChapter", chapterIndex);
    }

    //����� é�͸� ��ȯ�ϴ� �Լ�
    public int LoadSaveChapter()
    {
        return PlayerPrefs.GetInt("SaveChapter", 1);
    }
}
