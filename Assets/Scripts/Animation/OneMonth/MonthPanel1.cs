using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthPanel1 : MonoBehaviour
{
    public Sprite[] feeds = new Sprite[13];
    float fadeAlpha;
    int index;
    public GameObject feedImg;

    public Sprite[] pics_book = new Sprite[4];
    public Sprite[] pics_food = new Sprite[4];

    bool end;

    // Start is called before the first frame update
    void Start()
    {
        feedImg.SetActive(false);
        index = 0;
        end = false;
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
        index++;
        //이미지 전환
        while (index < 13)
        {
            gameObject.GetComponent<Image>().sprite = feeds[index];
            if (index==1)
            {
                feedImg.SetActive(true);
                string selectPic = GameManager.instance.selectBook;

                if (selectPic == "cat")
                {
                    Debug.Log("cat");
                    feedImg.GetComponent<Image>().sprite = pics_book[0];
                }
                else if (selectPic == "bread")
                {
                    feedImg.GetComponent<Image>().sprite = pics_book[1];
                }
                else if (selectPic == "chicken")
                {
                    feedImg.GetComponent<Image>().sprite = pics_book[2];
                }
                else if (selectPic == "dinner")
                {
                    feedImg.GetComponent<Image>().sprite = pics_book[3];
                }
            }
            else if(index==3)
            {
                feedImg.SetActive(true);
                string selectPic = GameManager.instance.orderFood;
                if (selectPic == "Omelet")
                {
                    feedImg.GetComponent<Image>().sprite = pics_food[0];
                }
                else if (selectPic == "Pasta")
                {
                    feedImg.GetComponent<Image>().sprite = pics_food[1];
                }
                else if (selectPic == "Sandwich")
                {
                    feedImg.GetComponent<Image>().sprite = pics_food[2];
                }
                else if (selectPic == "Steak")
                {
                    feedImg.GetComponent<Image>().sprite = pics_food[3];
                }
            }
            else if(index==4)
            {
                feedImg.SetActive(true);
                Sprite selectPic = (Sprite)GameManager.instance.likeAlbumart;
                feedImg.GetComponent<Image>().sprite = selectPic;
            }
            

            yield return new WaitForSeconds(1.0f); //0.01초 딜레이

            feedImg.SetActive(false);
            index++;
        }
        yield return new WaitForSeconds(5.0f); //0.01초 딜레이

        fadeAlpha = 1.0f;   //처음 알파값

        //어두워지기
        while (fadeAlpha > 0.0f)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(2.0f); //0.01초 딜레이

        end = true;

        gameObject.SetActive(false);

    }

    public void theEnd()
    {
        if(end)
        {
            //다음 씬 전환
            GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartEndingCredits();
        }
    }
}
