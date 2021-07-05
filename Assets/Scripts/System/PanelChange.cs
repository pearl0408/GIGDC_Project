using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
    //�г� ��ȯ ��ũ��Ʈ
    public GameObject settingPanel;

    public void OpenSettingPanel()
    {
        StartCoroutine(PanelOpenDelay(settingPanel, 0.5f));
    }

    public void CloseSettingPanel()
    {
        StartCoroutine(PanelCloseDelay(settingPanel, 0.5f));
    }

    //���̵� �� �� �ʰ� �����̸� �ְ�, �г��� ���� �ڷ�ƾ �Լ�
    IEnumerator PanelOpenDelay(GameObject PanelTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //���̵� �ƿ�
        yield return new WaitForSeconds(delayTime); //������
        PanelTitle.SetActive(true); //�г� Ȱ��ȭ
        this.GetComponent<Fade>().FadeIn();  //���̵� ��
    }

    //���̵� �� �� �ʰ� �����̸� �ְ�, �г��� �ݴ� �ڷ�ƾ �Լ�
    IEnumerator PanelCloseDelay(GameObject PanelTitle, float delayTime)
    {
        this.GetComponent<Fade>().FadeOut();  //���̵� �ƿ�
        yield return new WaitForSeconds(delayTime); //������
        PanelTitle.SetActive(false); //�г� Ȱ��ȭ
        this.GetComponent<Fade>().FadeIn();  //���̵� ��
    }
}
