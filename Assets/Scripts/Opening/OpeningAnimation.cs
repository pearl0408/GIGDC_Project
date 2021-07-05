using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OpeningAnimation : MonoBehaviour
{
    public bool Clockdown;
    GameObject minute;
    GameObject hour;

    float startTime;
    public float thisTime;
    public float totalTime;
    public Sprite[] panelImages = new Sprite[3];
    int index;
    bool goin;

    public float fadeAlpha;

    GameObject ImagePanel;
    GameObject lightPanel;

    GameObject nextPanel;
    //bool nextAnimationStart;

    // Start is called before the first frame update
    void Start()
    {
        Clockdown = false;
        minute = GameObject.Find("Minute");
        hour = GameObject.Find("Hour");
        ImagePanel = GameObject.Find("Pic");
        index = 0;
        ImagePanel.GetComponent<Image>().sprite = panelImages[index];
        goin = true;
        lightPanel = GameObject.Find("Blind");
        lightPanel.GetComponent<Animator>().speed = 0.0f;

        nextPanel = GameObject.Find("TalkFriend");
        nextPanel.SetActive(false);
        //nextAnimationStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerDown()
    {
        Clockdown = true;
        startTime = Time.time;
        lightPanel.GetComponent<Animator>().speed = 1.0f;
        Vibration.Vibrate(100);
        StartCoroutine(ClockRotate());
        //StartCoroutine(lightSet());
    }

    public void PointerUp()
    {
        Clockdown = false;
        totalTime += thisTime;
        lightPanel.GetComponent<Animator>().speed = 0.0f;
    }

    IEnumerator ClockRotate()
    {
        while (Clockdown)
        {
            //시계돌리기
            minute.transform.Rotate(new Vector3(0f, 0f, -360f) * Time.deltaTime);
            hour.transform.Rotate(new Vector3(0f, 0f, -60f) * Time.deltaTime);
            lightPanel.GetComponent<Image>().color = new Color(0, 0, 0, fadeAlpha);

            //타이머
            thisTime = Time.time - startTime;

            if ((totalTime + thisTime) > 3.0f && goin)
            {
                //패널 변경
                index++;
                ImagePanel.GetComponent<Image>().sprite = panelImages[index];
                index++;
                goin = false;
            }

            if ((totalTime + thisTime) > 6.0f)
            {
                ImagePanel.GetComponent<Image>().sprite = panelImages[index];
            }

            if((totalTime + thisTime) > 9.0f)
            {
                //카톡 패널 setActive
                nextPanel.SetActive(true);
                gameObject.SetActive(false);
                //nextAnimationStart = true;
            }

            yield return new WaitForSeconds(0.0001f);
        }
    }
}
