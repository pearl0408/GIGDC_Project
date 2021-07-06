using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockMove : MonoBehaviour
{
    //시계 바늘을 돌리면 화면이 어두워졌다 밝아졌다 하는 스크립트

    public Image LightImg;  //투명도를 조절할 이미지

    void Update()
    {
        if (Input.touchCount > 0)  //화면을 터치하면
        {
            Vector2 mPosition = Input.mousePosition;    //터치 좌표 저장
            Ray ray = Camera.main.ScreenPointToRay(mPosition);
        }
    }

    //시계바늘 회전 코드 작성 필요
}
