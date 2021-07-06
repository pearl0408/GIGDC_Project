using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTime : MonoBehaviour
{
    //현재 시간을 출력하는 스크립트

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
        System.DateTime dateTime = System.DateTime.Now; //현재 시간으로 초기화

        hour = dateTime.ToString("hh");  // 현재 시간을 가져옴
        min = dateTime.ToString("mm");    // 현재 분을 가져옴

        thisText.text = hour + ":" + min;   //현재 시간을 출력
    }
}
