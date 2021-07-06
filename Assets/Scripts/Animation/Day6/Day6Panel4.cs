using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day6Panel4 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;
    public GameObject nextButton;
    public GameObject sound;
    public GameObject BGM;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        StartCoroutine(nextGo());
    }

    IEnumerator nextGo()
    {
        BGM.GetComponent<AudioSource>().Stop();
        
        fadeAlpha = 0.0f;   //ó�� ���İ�

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01�� ������
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
        }
        sound.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f);

        fadeAlpha = 0.0f;   //ó�� ���İ�

        nextPanel.SetActive(true);

        while (fadeAlpha < 0.7f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01�� ������
            nextPanel.GetComponent<Image>().color = new Color(1, 1, 1, fadeAlpha);
        }

        nextButton.SetActive(true);
    }

    public void nextScene()
    {
        //������ ��ȯ
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
