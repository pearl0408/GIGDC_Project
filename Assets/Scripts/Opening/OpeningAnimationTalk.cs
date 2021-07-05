using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningAnimationTalk : MonoBehaviour
{
    public GameObject[] talk = new GameObject[3];
    int i;

    public GameObject posterBig;
    float zoomNum;


    public GameObject nextButton;
    public GameObject nextPanel;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        posterBig.transform.localScale = new Vector3(0f, 0f, 0f);
        nextButton.SetActive(false);
        nextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talkUp()
    {
        talk[i].SetActive(true);
        if(i<2)
        {
            i++;
        }       
    }

    public void zoomInPoster()
    {
        //posterBig.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        StartCoroutine(zoom());
    }

    IEnumerator zoom()
    {       
        while(zoomNum<1.0f)
        {
            zoomNum += 0.05f;
            posterBig.transform.localScale = new Vector3(zoomNum, zoomNum, zoomNum);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    public void nextScene()
    {
        StartCoroutine(nextGo());
    }

    IEnumerator nextGo()
    {
        yield return new WaitForSeconds(2.0f);

        float fadeAlpha = 0.0f;   //처음 알파값

        nextPanel.SetActive(true);

        while (fadeAlpha < 0.7f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            nextPanel.GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
        }

        nextButton.SetActive(true);
    }
}
