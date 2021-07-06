using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day5Panel2 : MonoBehaviour
{
    float fadeAlpha;
    public GameObject nextPanel;
    public GameObject nextButton;
    public GameObject musicAlbum;
    public GameObject musicTitle;

    // Start is called before the first frame update
    void Start()
    {
        musicAlbum.GetComponent<Image>().sprite = (Sprite)GameManager.instance.likeAlbumartList[0];
        musicTitle.GetComponent<Text>().text = GameManager.instance.playlistTitle;

        StartCoroutine(nextGo());
    }

    IEnumerator nextGo()
    {
        fadeAlpha = 0.0f;   //처음 알파값

        while (fadeAlpha < 1.0f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, fadeAlpha);
            musicAlbum.GetComponent<Image>().color = new Color(musicAlbum.GetComponent<Image>().color.r, musicAlbum.GetComponent<Image>().color.g, musicAlbum.GetComponent<Image>().color.b, fadeAlpha);
            musicTitle.GetComponent<Image>().color = new Color(musicTitle.GetComponent<Image>().color.r, musicTitle.GetComponent<Image>().color.g, musicTitle.GetComponent<Image>().color.b, fadeAlpha);
        }

        yield return new WaitForSeconds(2.0f);

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

    public void nextScene()
    {
        //다음씬 전환
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
