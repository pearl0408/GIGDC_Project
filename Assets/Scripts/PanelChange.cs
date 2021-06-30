using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
    //패널 전환 스크립트
    public GameObject settingPanel;

    public void OpenSettingPanel()
    {
        StartCoroutine(PanelOpenDelay(settingPanel, 0.5f));
    }

    public void CloseSettingPanel()
    {
        StartCoroutine(PanelCloseDelay(settingPanel, 0.5f));
    }

    //페이드 후 몇 초간 딜레이를 주고, 패널을 여는 코루틴 함수
    IEnumerator PanelOpenDelay(GameObject PanelTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //페이드 아웃
        yield return new WaitForSeconds(delayTime); //딜레이
        PanelTitle.SetActive(true); //패널 활성화
        this.GetComponent<Fade>().FadeIn();  //페이드 인
    }

    //페이드 후 몇 초간 딜레이를 주고, 패널을 닫는 코루틴 함수
    IEnumerator PanelCloseDelay(GameObject PanelTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //페이드 아웃
        yield return new WaitForSeconds(delayTime); //딜레이
        PanelTitle.SetActive(false); //패널 활성화
        this.GetComponent<Fade>().FadeIn();  //페이드 인
    }
}
