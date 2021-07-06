using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBG : MonoBehaviour
{
    //�ð��� ���� ��� ������ ���, ���������� �ٲٴ� �Լ�


    private int intHour;
    private string AMOrPM;
    private string hour;

    private Image thisBG;


    // Start is called before the first frame update
    void Start()
    {
        thisBG = this.GetComponent<Image>();
        CheckAndBGColorChange();
    }

    void Update()
    {
        CheckAndBGColorChange();
    }

    void CheckAndBGColorChange()
    {
        System.DateTime dateTime = System.DateTime.Now; //���� �ð����� �ʱ�ȭ

        hour = dateTime.ToString("hh");  // ���� �ð��� ������
        AMOrPM = dateTime.ToString("tt");    //����/���ĸ� ������
        intHour = int.Parse(hour);   //���ڸ� ���ڷ� ����

        if (intHour >= 6 && AMOrPM == "PM")  //���� �����̶��
        {
            thisBG.color = new Color(0.1f, 0.1f, 0.1f, 1f);   //��ũ���� ����
        }
        else if (intHour < 6 && AMOrPM == "AM")     //���� ���� 6�� �����̶��
        {
            thisBG.color = new Color(0.1f, 0.1f, 0.1f, 1f);   //��ũ���� ����
        }
        else
        {
            thisBG.color = new Color(1f, 1f, 1f, 1f);   //ȭ��Ʈ���� ����
        }
    }
}
