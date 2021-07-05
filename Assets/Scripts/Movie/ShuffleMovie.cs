using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum movies { action, animation, comedy, drama, horror, romance };    //��ȭ ������ ���� ����

public class ShuffleMovie : MonoBehaviour
{
    //��ȭ ����� �������� ���� ��ũ��Ʈ

    public Button[] movieList;   //��ȭ ��ư ���

    void Start()
    {
        Shuffle(movieList);  //�迭 ����

        //å ��ư ����
        for (int i = 0; i < 6; i++)
        {
            //��ư ����
            Button Btn_Movie = (Button)Instantiate(movieList[i]);   //��ư ����
            Btn_Movie.gameObject.transform.SetParent(this.gameObject.transform); //���� ������Ʈ�� �ڽ� ������Ʈ�� ����
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
