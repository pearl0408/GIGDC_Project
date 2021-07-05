using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour
{
    public GameObject panel1;
    public GameObject shoesMask;
    public GameObject shoes;


    public GameObject panel2;


    public GameObject bg1;
    public GameObject bg2;
    public GameObject me;

    public GameObject panel4;

    float width;
    float startTime;
    float fadeAlpha;


    // Start is called before the first frame update
    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel4.SetActive(false);
        bg1.SetActive(false);
        bg2.SetActive(false);
        me.SetActive(false);


        width = bg1.GetComponent<RectTransform>().rect.width;
        StartCoroutine(panel1Go());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator panel1Go()
    {
        panel1.SetActive(true);
        //등장하기
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            panel1.GetComponent<Image>().color = new Color(panel1.GetComponent<Image>().color.r, panel1.GetComponent<Image>().color.g, panel1.GetComponent<Image>().color.b, fadeAlpha);
            shoes.GetComponent<Image>().color = new Color(shoes.GetComponent<Image>().color.r, shoes.GetComponent<Image>().color.g, shoes.GetComponent<Image>().color.b, fadeAlpha);
            shoesMask.GetComponent<Image>().color = new Color(shoesMask.GetComponent<Image>().color.r, shoesMask.GetComponent<Image>().color.g, shoesMask.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(5.0f); //0.01초 딜레이

        fadeAlpha = 1.0f;   //처음 알파값

        //어두워지기
        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            panel1.GetComponent<Image>().color = new Color(panel1.GetComponent<Image>().color.r, panel1.GetComponent<Image>().color.g, panel1.GetComponent<Image>().color.b, fadeAlpha);
            shoes.GetComponent<Image>().color = new Color(shoes.GetComponent<Image>().color.r, shoes.GetComponent<Image>().color.g, shoes.GetComponent<Image>().color.b, fadeAlpha);
            shoesMask.GetComponent<Image>().color = new Color(shoesMask.GetComponent<Image>().color.r, shoesMask.GetComponent<Image>().color.g, shoesMask.GetComponent<Image>().color.b, fadeAlpha);
        }

        panel1.SetActive(false);

        
    
    
        panel2.SetActive(true);

        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            panel2.GetComponent<Image>().color = new Color(panel2.GetComponent<Image>().color.r, panel2.GetComponent<Image>().color.g, panel2.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(5.0f); //0.01초 딜레이

        //갑자기 어두워지기
        panel2.GetComponent<Image>().color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(2.0f); //0.01초 딜레이

        panel1.SetActive(false);

        
    
        bg1.SetActive(true);
        bg2.SetActive(true);
        me.SetActive(true);

        //등장하기
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            bg1.GetComponent<Image>().color = new Color(bg1.GetComponent<Image>().color.r, bg1.GetComponent<Image>().color.g, bg1.GetComponent<Image>().color.b, fadeAlpha);
            bg2.GetComponent<Image>().color = new Color(bg2.GetComponent<Image>().color.r, bg2.GetComponent<Image>().color.g, bg2.GetComponent<Image>().color.b, fadeAlpha);
            me.GetComponent<Image>().color = new Color(me.GetComponent<Image>().color.r, me.GetComponent<Image>().color.g, me.GetComponent<Image>().color.b, fadeAlpha);
        }

        startTime = Time.time;
        while (Time.time - startTime < 20.0)
        {
            bg1.transform.Translate(new Vector3(3, 0, 0));
            bg2.transform.Translate(new Vector3(3, 0, 0));


            if (bg1.transform.position.x > 3000 + 1080)
            {
                bg1.transform.position = new Vector2(bg2.transform.position.x - width + 10, bg1.transform.position.y);
            }
            else if (bg2.transform.position.x > 3000 + 1080)
            {
                bg2.transform.position = new Vector2(bg1.transform.position.x - width + 10, bg2.transform.position.y);
            }

            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        //현재 패널 페이드 아웃
        fadeAlpha = 1.0f;   //처음 알파값

        //어두워지기
        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            bg1.GetComponent<Image>().color = new Color(bg1.GetComponent<Image>().color.r, bg1.GetComponent<Image>().color.g, bg1.GetComponent<Image>().color.b, fadeAlpha);
            bg2.GetComponent<Image>().color = new Color(bg2.GetComponent<Image>().color.r, bg2.GetComponent<Image>().color.g, bg2.GetComponent<Image>().color.b, fadeAlpha);
            me.GetComponent<Image>().color = new Color(me.GetComponent<Image>().color.r, me.GetComponent<Image>().color.g, me.GetComponent<Image>().color.b, fadeAlpha);
        }

        bg1.SetActive(false);
        bg2.SetActive(false);
        me.SetActive(false);

        
        //등장하기
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            panel4.GetComponent<Image>().color = new Color(panel4.GetComponent<Image>().color.r, panel4.GetComponent<Image>().color.g, panel4.GetComponent<Image>().color.b, fadeAlpha);
        }
    }
}
