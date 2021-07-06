using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day4Panel1 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Panel1());
    }

    IEnumerator Panel1()
    {
        //gameObject.SetActive(true);
        //�����ϱ�
        fadeAlpha = 0.0f;   //ó�� ���İ�

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01�� ������
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
        }
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3.0f); //0.01�� ������

        fadeAlpha = 1.0f;   //ó�� ���İ�

        //��ο�����
        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01�� ������
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
        }

        nextPanel.SetActive(true);

        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
