using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day4Panel3 : MonoBehaviour
{
    float fadeAlpha;
    float height;

    public Sprite[] foodList = new Sprite[4];
    public GameObject food;
    public GameObject nextPanel;
    public GameObject camera;
    public GameObject camerashut1;
    public GameObject camerashut2;

    // Start is called before the first frame update
    void Start()
    {
        food.GetComponent<Animator>().speed = 0;
        camera.SetActive(false);
        height = camerashut1.GetComponent<RectTransform>().rect.height;
        string foodName = GameManager.instance.orderFood;
        if (foodName == "Omelet")
        {
            food.GetComponent<Image>().sprite = foodList[0];
        }
        else if (foodName == "Pasta")
        {
            food.GetComponent<Image>().sprite = foodList[1];
        }
        else if (foodName == "Sandwich")
        {
            food.GetComponent<Image>().sprite = foodList[2];
        }
        else if (foodName == "Steak")
        {
            food.GetComponent<Image>().sprite = foodList[3];
        }
        StartCoroutine(Panel3());
    }

    IEnumerator Panel3()
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
        food.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f); //0.01초 딜레이
        camera.SetActive(true);

        yield return new WaitForSeconds(1.0f); //0.01초 딜레이
        food.GetComponent<Animator>().speed = 1;

        yield return new WaitForSeconds(3.0f); //0.01초 딜레이

        float startPos = camerashut1.transform.position.y;
        camera.GetComponent<AudioSource>().Play();
        while (startPos-camerashut1.transform.position.y<height)
        {
            
            camerashut1.transform.Translate(new Vector2(0, -100));
            camerashut2.transform.Translate(new Vector2(0, 100));
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        yield return new WaitForSeconds(2.0f); //0.01초 딜레이

        nextPanel.SetActive(true);

        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
