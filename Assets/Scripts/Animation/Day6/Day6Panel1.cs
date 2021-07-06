using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day6Panel1 : MonoBehaviour
{
    public GameObject buildingR1;
    public GameObject buildingR2;
    public GameObject buildingL1;
    public GameObject buildingL2;
    public GameObject myPhone;

    public GameObject myPosition;

    float fadeAlpha;
    public GameObject nextPanel;
    float startTime;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(buildingMove());
        StartCoroutine(Panel1());
    }

    IEnumerator buildingMove()
    {
        startTime = Time.time;
        while (Time.time - startTime < 10.0)
        {
            buildingL1.transform.Translate(new Vector3(-0.8f, -1, 0));
            buildingL2.transform.Translate(new Vector3(-0.8f, -1, 0));

            buildingR1.transform.Translate(new Vector3(0.8f, -1, 0));
            buildingR2.transform.Translate(new Vector3(0.8f, -1, 0));

            myPosition.transform.Translate(new Vector3(-0.1f, 0.1f, 0));

            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }
    }
    IEnumerator Panel1()
    {
        //gameObject.SetActive(true);
        //등장하기
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
            buildingL1.GetComponent<Image>().color = new Color(buildingL1.GetComponent<Image>().color.r, buildingL1.GetComponent<Image>().color.g, buildingL1.GetComponent<Image>().color.b, fadeAlpha);
            buildingR1.GetComponent<Image>().color = new Color(buildingR1.GetComponent<Image>().color.r, buildingR1.GetComponent<Image>().color.g, buildingR1.GetComponent<Image>().color.b, fadeAlpha);
            myPhone.GetComponent<Image>().color = new Color(myPhone.GetComponent<Image>().color.r, myPhone.GetComponent<Image>().color.g, myPhone.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(5.0f); //0.01초 딜레이

        fadeAlpha = 1.0f;   //처음 알파값

        //어두워지기
        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
            buildingL2.GetComponent<Image>().color = new Color(buildingL2.GetComponent<Image>().color.r, buildingL2.GetComponent<Image>().color.g, buildingL2.GetComponent<Image>().color.b, fadeAlpha);
            buildingR2.GetComponent<Image>().color = new Color(buildingR2.GetComponent<Image>().color.r, buildingR2.GetComponent<Image>().color.g, buildingR2.GetComponent<Image>().color.b, fadeAlpha);
            myPhone.GetComponent<Image>().color = new Color(myPhone.GetComponent<Image>().color.r, myPhone.GetComponent<Image>().color.g, myPhone.GetComponent<Image>().color.b, fadeAlpha);
        }

        nextPanel.SetActive(true);

        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
