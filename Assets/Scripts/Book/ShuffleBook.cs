using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleBook : MonoBehaviour
{
    //å ����� �������� ���� ��ũ��Ʈ

    public Button[] bookList;   //å ��ư ���

    void Start()
    {
        Shuffle(bookList);  //�迭 ����

        //å ��ư ����
        for (int i = 0; i < 6; i++)
        {
            //��ư ����
            Button Btn_Book = (Button)Instantiate(bookList[i]);   //��ư ����
            Btn_Book.gameObject.transform.SetParent(this.gameObject.transform); //���� ������Ʈ�� �ڽ� ������Ʈ�� ����
        }
    }

    //���� �Լ�
    void Shuffle(Button[] btnArray)
    {
        int random1, random2;   //�ε���
        Button tempBtn; //�ӽ� ��ư

        for (int i = 0; i < btnArray.Length; i++)
        {
            random1 = Random.Range(0, btnArray.Length);    //���� �ε��� ����
            random2 = Random.Range(0, btnArray.Length);    //���� �ε��� ����

            tempBtn = btnArray[random1];    //�ӽ� ��ư ����
            btnArray[random1] = btnArray[random2];  //��ư ����
            btnArray[random2] = tempBtn;    //�ӽ� ��ư ����
        }
    }
}
