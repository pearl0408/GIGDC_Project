using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchFood : MonoBehaviour
{
    //���� �˻��ϴ� ��ũ��Ʈ

    public Text text_Keyword;   //Ű���� �Է�â
    public GameObject searchResultPanel;    //�˻� ��� �г�

    public void TypingOmelet()
    {
        text_Keyword.text = "���ɷ� ������"; //�ؽ�Ʈ �Է�
        GameManager.instance.searchFood = "���ɷ�";    //�̱��濡 ����
    }

    public void TypingPasta()
    {
        text_Keyword.text = "�Ľ�Ÿ ������"; //�ؽ�Ʈ �Է�
        GameManager.instance.searchFood = "�Ľ�Ÿ";    //�̱��濡 ����
    }

    public void TypingSandwich()
    {
        text_Keyword.text = "������ġ ������"; //�ؽ�Ʈ �Է�
        GameManager.instance.searchFood = "������ġ";    //�̱��濡 ����
    }

    public void TypingSteak()
    {
        text_Keyword.text = "������ũ ������"; //�ؽ�Ʈ �Է�
        GameManager.instance.searchFood = "������ũ";    //�̱��濡 ����
    }

    //�˻� ����� �����ִ� �Լ�(�˻� ��ư �̺�Ʈ)
    public void checkFood()
    {
        string searchKey = text_Keyword.text;   //�˻��� �ؽ�Ʈ�� ������
        if (searchKey != "") //���� ������ �ƴ϶��
        {
            searchResultPanel.gameObject.SetActive(true);   //�˻� ���â Ȱ��ȭ
        }
    }
}
