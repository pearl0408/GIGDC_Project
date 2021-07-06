using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBG : MonoBehaviour
{
    //시간에 따라 배경 색깔을 흰색, 검은색으로 바꾸는 함수


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
        System.DateTime dateTime = System.DateTime.Now; //현재 시간으로 초기화

        hour = dateTime.ToString("hh");  // 현재 시간을 가져옴
        AMOrPM = dateTime.ToString("tt");    //오전/오후를 가져옴
        intHour = int.Parse(hour);   //문자를 숫자로 변경

        if (intHour >= 6 && AMOrPM == "PM")  //만약 저녁이라면
        {
            thisBG.color = new Color(0.1f, 0.1f, 0.1f, 1f);   //다크모드로 변경
        }
        else if (intHour < 6 && AMOrPM == "AM")     //만약 오전 6시 이전이라면
        {
            thisBG.color = new Color(0.1f, 0.1f, 0.1f, 1f);   //다크모드로 변경
        }
        else
        {
            thisBG.color = new Color(1f, 1f, 1f, 1f);   //화이트모드로 변경
        }
    }
}
