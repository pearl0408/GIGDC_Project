using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    //�� ��ȯ ���̵� �Լ�
    public Image FadeImg;   //���̵� ȿ���� ����� �̹���

    void Start()
    {
        //������ ���۵Ǹ� ���̵��� �Լ� ����
        FadeIn();
    }

    //���̵��� �Լ�(����: 100- > 0)
    public void FadeIn()
    {
        StartCoroutine(CoFadeIn(FadeImg)); //���̵��� �ڷ�ƾ ����
    }

    //���̵�ƿ� �Լ�(����: 0- > 100)
    public void FadeOut()
    {
        StartCoroutine(CoFadeOut(FadeImg)); //���̵�ƿ� �ڷ�ƾ ����
    }

    //���̵��� �ڷ�ƾ �Լ�
    IEnumerator CoFadeIn(Image fadeImg)
    {
        float fadeAlpha = 1.0f;   //ó�� ���İ�

        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.1f;
            yield return new WaitForSeconds(0.01f); //0.01�� ������
            fadeImg.color = new Color(0, 0, 0, fadeAlpha);
        }
    }

    //���̵�ƿ� �ڷ�ƾ �Լ�
    IEnumerator CoFadeOut(Image fadeImg)
    {
        float fadeAlpha = 0f;   //ó�� ���İ�

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.1f;
            yield return new WaitForSeconds(0.01f); //0.01�� ������
            fadeImg.color = new Color(0, 0, 0, fadeAlpha);
        }
    }
}
