using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveChapter : MonoBehaviour
{
    //é�Ϳ� ���� ����� �����ϴ� �Լ�

    public Button[] chapterList;    //é�� �����Ű�� ��ư
    public Image[] checkLine;   //�̹� �Ϸ��� é�Ϳ� ǥ���� ��

    void OnEnable()     //Ȱ��ȭ �� ������
    {
        int save = PlayerPrefs.GetInt("SaveDay", 1);

        chapterList[save].gameObject.SetActive(true);   //���������� �� é���� ���� é�� ���۵ǰ�

        for (int i = 0; i < save; i++)
        {
            chapterList[i].gameObject.SetActive(true);
            checkLine[i].gameObject.SetActive(true);
        }
    }
}
