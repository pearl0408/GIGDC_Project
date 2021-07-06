using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1Panel3 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;
    public GameObject bg2;
    public GameObject me;

    float startTime;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        bg2.SetActive(true);
        me.SetActive(true);
        width = gameObject.GetComponent<RectTransform>().rect.width;
        StartCoroutine(SceneStart());
        StartCoroutine(BGMove());
        StartCoroutine(walkSound());
    }
    IEnumerator walkSound()
    {
        while (Time.time - startTime < 20.0)
        {
            me.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.6f); //0.01초 딜레이
        }

    }
    IEnumerator BGMove()
    {
        gameObject.GetComponent<AudioSource>().Play();
        startTime = Time.time;
        while (Time.time - startTime < 20.0)
        {
            gameObject.transform.Translate(new Vector3(3, 0, 0));
            bg2.transform.Translate(new Vector3(3, 0, 0));


            if (gameObject.transform.position.x > 3000 + 1080)
            {
                gameObject.transform.position = new Vector2(bg2.transform.position.x - width + 10, gameObject.transform.position.y);
            }
            else if (bg2.transform.position.x > 3000 + 1080)
            {
                bg2.transform.position = new Vector2(gameObject.transform.position.x - width + 10, bg2.transform.position.y);
            }

            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }
    }

    IEnumerator SceneStart()
    {
        //등장하기
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
            bg2.GetComponent<Image>().color = new Color(bg2.GetComponent<Image>().color.r, bg2.GetComponent<Image>().color.g, bg2.GetComponent<Image>().color.b, fadeAlpha);
            me.GetComponent<Image>().color = new Color(me.GetComponent<Image>().color.r, me.GetComponent<Image>().color.g, me.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(15.0f); //0.01초 딜레이        

        //현재 패널 페이드 아웃
        fadeAlpha = 1.0f;   //처음 알파값

        //어두워지기
        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
            bg2.GetComponent<Image>().color = new Color(bg2.GetComponent<Image>().color.r, bg2.GetComponent<Image>().color.g, bg2.GetComponent<Image>().color.b, fadeAlpha);
            me.GetComponent<Image>().color = new Color(me.GetComponent<Image>().color.r, me.GetComponent<Image>().color.g, me.GetComponent<Image>().color.b, fadeAlpha);
        }

        nextPanel.SetActive(true);

        gameObject.SetActive(false);
        bg2.SetActive(false);
        me.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
