using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day7Panel1 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;
    public GameObject paperBtn;

    bool ClickOk;

    // Start is called before the first frame update
    void Start()
    {
        ClickOk = false;
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
            paperBtn.GetComponent<Image>().color = new Color(paperBtn.GetComponent<Image>().color.r, paperBtn.GetComponent<Image>().color.g, paperBtn.GetComponent<Image>().color.b, fadeAlpha);
        }

        ClickOk = true;
        
    }

    public void clickPaper()
    {
        if (ClickOk)
        {
            nextPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
