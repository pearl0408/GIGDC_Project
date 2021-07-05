using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnswerConflict : MonoBehaviour
{
    //������ ������ �亯�� �����ϴ� Ŭ����

    string[] playerAnswerList = { "������ �ô밡 �޶��", "���� �ູ���� ���� �ɿ�",
        "�̷��� ��� ���� �ʾƿ�", "������� �� ���帶�� �����", "�λ��� ��� ���а� �����",
        "�ٸ� �� ã���� ����", "�� �λ��̴� ���� �����ϰ� �����ϰ� �̰ܳ� �ſ���"};  //���ΰ� �亯 �迭 ����

    public int currentAnswerIndex; //���� ���õ� �ؽ�Ʈ ��ȣ
    public Text answerText; //�÷��̾� �亯 �ؽ�Ʈ

    void Start()   
    {
        Shuffle(playerAnswerList);  //���� ���۵Ǹ� ��� ������ ����

        //���� ������ ��縦 ������
        currentAnswerIndex = 0;
        ChangeShowAnswer();

    }

    //���� ���� �Ѿ�� ��ư �̺�Ʈ
    public void NextAnswer()
    {
        if (currentAnswerIndex == 6)    //���� ���� �亯�� ���ٸ�
        {
            currentAnswerIndex = 0; //���� ó������ �̵�
        }
        else //�ƴ϶��
        {
            currentAnswerIndex++;   //���� �亯 ������
        }

        ChangeShowAnswer(); //�����ִ� �亯 ����
    }

    //���� ���� ���ư��� ��ư �̺�Ʈ
    public void BeforeAnswer()
    {
        if (currentAnswerIndex == 0)    //���� ���� �亯�� ���ٸ�
        {
            currentAnswerIndex = 6; //���� ������ �̵�
        }
        else //�ƴ϶��
        {
            currentAnswerIndex--;   //���� �亯 ������
        }

        ChangeShowAnswer(); //�����ִ� �亯 ����
    }

    //���� �亯 ��ȣ�� ���� �亯 �ؽ�Ʈ�� �����ϴ� �Լ�
    public void ChangeShowAnswer()
    {
        answerText.text = playerAnswerList[currentAnswerIndex]; //�ؽ�Ʈ�� ������
    }

    //������ �亯 �ؽ�Ʈ�� ��ȯ�ϴ� �Լ�
    public string returnAnswerText()
    {
        return playerAnswerList[currentAnswerIndex];
    }

    //���� �Լ�
    void Shuffle(string[] stringArray)
    {
        int random1, random2;   //�ε���
        string tempString; //�ӽ� ��ư

        for (int i = 0; i < stringArray.Length; i++)
        {
            random1 = Random.Range(0, stringArray.Length);    //���� �ε��� ����
            random2 = Random.Range(0, stringArray.Length);    //���� �ε��� ����

            tempString = stringArray[random1];    //�ӽ� ��ư ����
            stringArray[random1] = stringArray[random2];  //��ư ����
            stringArray[random2] = tempString;    //�ӽ� ��ư ����
        }
    }
}
