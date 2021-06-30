using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunAndMoon : MonoBehaviour
{
    //시간에 따라 해와 달 그림이 바뀌는 스크립트

    public Sprite[] SunMoon;    //해와 달 스프라이트 배열
    public int intHour;
    public string AMOrPM;

    void Start()
    {
        System.DateTime dateTime = System.DateTime.Now; //현재 시간으로 초기화

        string hour = dateTime.ToString("hh");  // 현재 시간을 가져옴
        AMOrPM = dateTime.ToString("tt");    //오전/오후를 가져옴
        intHour = int.Parse(hour);   //문자를 숫자로 변경

        if (intHour >= 6 && AMOrPM == "PM")  //만약 저녁이라면
        {
            this.GetComponent<Image>().sprite = SunMoon[1];    //달 그림으로 변경
        }
        else
        {
            this.GetComponent<Image>().sprite = SunMoon[0];    //해 그림으로 변경
        }

    }
}
