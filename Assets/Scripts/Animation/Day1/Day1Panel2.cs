using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1Panel2 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneStart());
    }


    IEnumerator SceneStart()
    {
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(5.0f); //0.01초 딜레이

        //갑자기 어두워지기
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(2.0f); //0.01초 딜레이

        nextPanel.SetActive(true);
        gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
