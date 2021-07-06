using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour
{
    //시간에 따라 화이트 모드, 다크 모드로 바꾸는 함수

    public Sprite[] modeImg;    //바꿀 이미지

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
        System.DateTime dateTime = System.DateTime.Now; //현재 시간으로 초기화

        hour = dateTime.ToString("hh");  // 현재 시간을 가져옴
        AMOrPM = dateTime.ToString("tt");    //오전/오후를 가져옴
        intHour = int.Parse(hour);   //문자를 숫자로 변경

        if (intHour >= 6 && AMOrPM == "PM")  //만약 저녁 6시 이후라면
        {
            this.GetComponent<Image>().sprite = modeImg[1];    //다크모드로 변경

        }
        else if (intHour < 6 && AMOrPM == "AM")     //만약 오전 6시 이전이라면
        {
            this.GetComponent<Image>().sprite = modeImg[1];    //다크모드로 변경
        }
        else
        {
            this.GetComponent<Image>().sprite = modeImg[0];    //화이트모드로 변경
        }
    }
}
