using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day7Panel2 : MonoBehaviour
{
    public GameObject Paper;
    float zoomNum;

    float fadeAlpha;
    public GameObject nextPanel;
    public GameObject BeforePanel;
    public GameObject BeforePaperBtn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(zoom());
    }

    IEnumerator zoom()
    {
        while (zoomNum < 1.0f)
        {
            zoomNum += 0.03f;
            Paper.transform.localScale = new Vector3(zoomNum, zoomNum, zoomNum);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    public void clickPapaer()
    {
        StartCoroutine(goNext());
    }

    IEnumerator goNext()
    {
        fadeAlpha = 1.0f;   //처음 알파값

        //어두워지기
        
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        Paper.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        BeforePanel.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        BeforePaperBtn.GetComponent<Image>().color = new Color(0, 0, 0, 1);



        yield return new WaitForSeconds(2.0f); //0.01초 딜레이
        
        nextPanel.SetActive(true);

        BeforePanel.SetActive(false);
        gameObject.SetActive(false);

    }
}
