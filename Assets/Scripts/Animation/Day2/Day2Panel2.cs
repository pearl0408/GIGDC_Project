using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day2Panel2 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;
    public GameObject nextButton;

    public GameObject sky;
    public GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        sky.SetActive(true);
        StartCoroutine(nextGo());
        StartCoroutine(cloudMove());
    }

    IEnumerator cloudMove()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 20.0)
        {
            cloud.transform.Translate(new Vector2(-0.8f, 0));
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }
    }
    IEnumerator nextGo()
    {
        fadeAlpha = 0.0f;   //처음 알파값
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f); //0.01초 딜레이

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
            sky.GetComponent<Image>().color = new Color(sky.GetComponent<Image>().color.r, sky.GetComponent<Image>().color.g, sky.GetComponent<Image>().color.b, fadeAlpha);
            

        }
        cloud.SetActive(true);
        sky.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(5.0f);

        fadeAlpha = 0.0f;   //처음 알파값

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
