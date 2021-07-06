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
    public GameObject Shutdown;
    public GameObject creditBox;
    public GameObject airplane;

    bool canGoHome;

    // Start is called before the first frame update
    void Start()
    {
        canGoHome = false;
        lastTalk = GameObject.Find("EndTalk");
        lastTalk.SetActive(false);

        i = 0;
        Panels[0].SetActive(true);
        Shutdown.SetActive(false);
        //StartCoroutine(FlashFirst());
        StartCoroutine(FlashFirst());
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if (i == 2 && fadeAlpha > 0.5)
            {
                float zoomNum=2.5f;
                Shutdown.SetActive(true);
                while (zoomNum > 1.0f)
                {
                    zoomNum -= 0.01f;
                    Shutdown.transform.localScale = new Vector3(zoomNum, zoomNum, zoomNum);
                    yield return new WaitForSeconds(0.0001f);
                }
            }
            //페이드 아웃
            yield return new WaitForSeconds(8.0f); //10초 딜레이

            fadeAlpha = 1.0f;   //처음 알파값

            while (fadeAlpha > 0.0f)
            {
                fadeAlpha -= 0.01f;
                yield return new WaitForSeconds(0.01f); //0.01초 딜레이
                Panels[i].GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
                if (i == 2)
                {
                    Shutdown.GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
                }
            }

            Panels[i].SetActive(false);

            i++;
        }

        creditBox.SetActive(false);

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

        //비행기 날아가기
        float zoomair = 1.0f;
        for (int i=0; i<90; i++)
        {
            zoomair += 0.03f;
            airplane.transform.Translate(new Vector2(-10, 10));
            airplane.transform.localScale= new Vector3(zoomair, zoomair, zoomair);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        canGoHome = true;
    }

    //마지막 공항씬에서 클릭하면 홈으로 돌아가도록 하는 함수
    public void endGoHome()
    {
        if (canGoHome)
        {
            //홈으로 전환
            Debug.Log("홈으로 가자");

            //bgm 재생 종료
            this.GetComponent<AudioSource>().Stop();
        }
    }
}
