using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{
    //�ð��� ���� �ؽ�Ʈ ������ ���, ���������� �ٲٴ� �Լ�


    private int intHour;
    private string AMOrPM;
    private string hour;

    private Text thisText;


    // Start is called before the first frame update
    void Start()
    {
        thisText = this.GetComponent<Text>();
        CheckAndTextColorChange();
    }

    void Update()
    {
        CheckAndTextColorChange();
    }

    void CheckAndTextColorChange()
    {
        System.DateTime dateTime = System.DateTime.Now; //���� �ð����� �ʱ�ȭ

        hour = dateTime.ToString("hh");  // ���� �ð��� ������
        AMOrPM = dateTime.ToString("tt");    //����/���ĸ� ������
        intHour = int.Parse(hour);   //���ڸ� ���ڷ� ����

        if (intHour >= 6 && AMOrPM == "PM")  //���� �����̶��
        {
            thisText.color = Color.white;   //��ũ���� ����
        }
        else if (intHour < 6 && AMOrPM == "AM")     //���� ���� 6�� �����̶��
        {
            thisText.color = Color.white;   //��ũ���� ����
        }
        else
        {
            thisText.color = Color.black;    //ȭ��Ʈ���� ����
        }
    }
}
