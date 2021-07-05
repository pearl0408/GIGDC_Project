using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunAndMoon : MonoBehaviour
{
    //�ð��� ���� �ؿ� �� �׸��� �ٲ�� ��ũ��Ʈ

    public Sprite[] SunMoon;    //�ؿ� �� ��������Ʈ �迭
    public int intHour;
    public string AMOrPM;

    void Start()
    {
        System.DateTime dateTime = System.DateTime.Now; //���� �ð����� �ʱ�ȭ

        string hour = dateTime.ToString("hh");  // ���� �ð��� ������
        AMOrPM = dateTime.ToString("tt");    //����/���ĸ� ������
        intHour = int.Parse(hour);   //���ڸ� ���ڷ� ����

        if (intHour >= 6 && AMOrPM == "PM")  //���� �����̶��
        {
            this.GetComponent<Image>().sprite = SunMoon[1];    //�� �׸����� ����
        }
        else
        {
            this.GetComponent<Image>().sprite = SunMoon[0];    //�� �׸����� ����
        }

    }
}
