using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicFlash : MonoBehaviour
{
    public GameObject[] Panels =new GameObject[8];
    int i;
    public GameObject lastTalk;
    float fadeAlpha;
    public GameObject End;

    bool canGoHome;

    // Start is called before the first frame update
    void Start()
    {
        canGoHome = false;
        lastTalk = GameObject.Find("EndTalk");
        lastTalk.SetActive(false);

        i = 0;
        Panels[0].SetActive(true);
        //StartCoroutine(FlashFirst());
        StartCoroutine(FlashFirst());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&canGoHome)
        {
            //Ȩ���� ��ȯ
            Debug.Log("Ȩ���� ����");
        }
    }

    IEnumerator FlashFirst()
    {
        while(i<8)
        {           
            //���̵� ��
            yield return new WaitForSeconds(1.0f); //0.01�� ������

            fadeAlpha = 0.0f;   //ó�� ���İ�

            Panels[i].SetActive(true);

            while (fadeAlpha < 1.0f)
            {
                fadeAlpha += 0.01f;
                yield return new WaitForSeconds(0.01f); //0.01�� ������
                Panels[i].GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
            }
            
            //���̵� �ƿ�
            yield return new WaitForSeconds(2.0f); //10�� ������

            fadeAlpha = 1.0f;   //ó�� ���İ�

            while (fadeAlpha > 0.0f)
            {
                fadeAlpha -= 0.01f;
                yield return new WaitForSeconds(0.01f); //0.01�� ������
                Panels[i].GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
            }

            Panels[i].SetActive(false);

            i++;
        }
        yield return new WaitForSeconds(2.0f); //0.01�� ������

        lastTalk.SetActive(true);

        yield return new WaitForSeconds(3.0f); //0.01�� ������

        lastTalk.SetActive(false);

        //yield return new WaitForSeconds(1.0f); //0.01�� ������

        //���̵� ��
        fadeAlpha = 0.0f;   //ó�� ���İ�

        End.SetActive(true);

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01�� ������
            End.GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
        }

        canGoHome = true;
    }
}
