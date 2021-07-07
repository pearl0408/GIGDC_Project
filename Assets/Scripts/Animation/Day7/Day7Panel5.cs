using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day7Panel5 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;
    public GameObject BGM;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Panel2());
    }

    IEnumerator Panel2()
    {
        //gameObject.SetActive(true);
        //등장하기
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(2.0f); //0.01초 딜레이

        fadeAlpha = 1.0f;   //처음 알파값

        //어두워지기
        
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(2.0f); //0.01초 딜레이
        BGM.GetComponent<AudioSource>().Stop();

        nextPanel.SetActive(true);

        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
