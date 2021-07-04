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
            //홈으로 전환
            Debug.Log("홈으로 가자");
        }
    }

    IEnumerator FlashFirst()
    {
        while(i<8)
        {           
            //페이드 인
            yield return new WaitForSeconds(1.0f); //0.01초 딜레이

            fadeAlpha = 0.0f;   //처음 알파값

            Panels[i].SetActive(true);

            while (fadeAlpha < 1.0f)
            {
                fadeAlpha += 0.01f;
                yield return new WaitForSeconds(0.01f); //0.01초 딜레이
                Panels[i].GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
            }
            
            //페이드 아웃
            yield return new WaitForSeconds(2.0f); //10초 딜레이

            fadeAlpha = 1.0f;   //처음 알파값

            while (fadeAlpha > 0.0f)
            {
                fadeAlpha -= 0.01f;
                yield return new WaitForSeconds(0.01f); //0.01초 딜레이
                Panels[i].GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
            }

            Panels[i].SetActive(false);

            i++;
        }
        yield return new WaitForSeconds(2.0f); //0.01초 딜레이

        lastTalk.SetActive(true);

        yield return new WaitForSeconds(3.0f); //0.01초 딜레이

        lastTalk.SetActive(false);

        //yield return new WaitForSeconds(1.0f); //0.01초 딜레이

        //페이드 인
        fadeAlpha = 0.0f;   //처음 알파값

        End.SetActive(true);

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            End.GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
        }

        canGoHome = true;
    }
}
