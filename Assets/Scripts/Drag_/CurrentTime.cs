using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTime : MonoBehaviour
{
    //���� �ð��� ����ϴ� ��ũ��Ʈ

    private string hour;
    private string min;

    private Text thisText;

    void Start()
    {
        thisText = this.GetComponent<Text>();
        CheckCurrentTime();
    }

    void Update()
    {
        CheckCurrentTime();
    }

    void CheckCurrentTime()
    {
        System.DateTime dateTime = System.DateTime.Now; //���� �ð����� �ʱ�ȭ

        hour = dateTime.ToString("hh");  // ���� �ð��� ������
        min = dateTime.ToString("mm");    // ���� ���� ������

        thisText.text = hour + ":" + min;   //���� �ð��� ���
    }
}
