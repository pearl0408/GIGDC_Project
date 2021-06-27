using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̱��� �Լ�: ���� �����͸� ����

    public static GameManager instance; //�̱��� ������ ����ϱ� ���� ���� ����

    public int saveDay; //���������� ����� ���Ǽҵ� ��¥

    //���۰� ���ÿ� �̱��� ����
    void Awake()
    {
        //�̱��� ���� instance�� �̹� �ִٸ�
        if (instance)
        {
            DestroyImmediate(gameObject);   //����
        }

        instance = this;    //������ �ν��Ͻ��� �����.
        DontDestroyOnLoad(gameObject);  //���� �ٲ� ��� ������Ŵ

        //���� �ʱ�ȭ
        saveDay = PlayerPrefs.GetInt("SaveDay", 1);    //���������� ����� ���Ǽҵ� ȸ���� ������. ���� ���ٸ� 1�� ������.
    }
}