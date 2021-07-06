using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour
{
    //�ð��� ���� ȭ��Ʈ ���, ��ũ ���� �ٲٴ� �Լ�

    public Sprite[] modeImg;    //�ٲ� �̹���

    private int intHour;
    private string AMOrPM;
    private string hour;

    void Start()
    {
        CheckAndChange();
    }

    void Upate()
    {
        CheckAndChange();
    }

    void CheckAndChange()
    {
        System.DateTime dateTime = System.DateTime.Now; //���� �ð����� �ʱ�ȭ

        hour = dateTime.ToString("hh");  // ���� �ð��� ������
        AMOrPM = dateTime.ToString("tt");    //����/���ĸ� ������
        intHour = int.Parse(hour);   //���ڸ� ���ڷ� ����

        if (intHour >= 6 && AMOrPM == "PM")  //���� ���� 6�� ���Ķ��
        {
            this.GetComponent<Image>().sprite = modeImg[1];    //��ũ���� ����

        }
        else if (intHour < 6 && AMOrPM == "AM")     //���� ���� 6�� �����̶��
        {
            this.GetComponent<Image>().sprite = modeImg[1];    //��ũ���� ����
        }
        else
        {
            this.GetComponent<Image>().sprite = modeImg[0];    //ȭ��Ʈ���� ����
        }
    }
}
