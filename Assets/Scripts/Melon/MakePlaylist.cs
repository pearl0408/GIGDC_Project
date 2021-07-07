using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MakePlaylist : MonoBehaviour
{
    int musicNum;
    bool[] musicLlkeList = new bool[10];
    public Sprite[] albumartList = new Sprite[10];

    Image nowHeart;

    GameObject howManyMusic;
    float BGVol;

    GameObject playMusic;
    bool musicPlaying;
    int nowMusicindex;
    GameObject nowMusic;

    public Sprite RedHeart;
    public Sprite EmptyHeart;

    //테스트용
    //public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        musicNum = 0;
        howManyMusic = GameObject.Find("HowManyMusic");
        musicPlaying = false;
        BGVol = PlayerPrefs.GetFloat("BGVol", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(int index)
    {
        if(musicLlkeList[index]==false)
        {
            musicLlkeList[index] = true;
            musicNum++;
        }
        else
        {
            musicLlkeList[index] = false;
            musicNum--;
        }

        howManyMusic.GetComponent<Text>().text = "담은 곡 : " + musicNum + "개";
    }

    public void MusicPlay(int musicIndex)
    {
        playMusic = GameObject.Find("Song" + musicIndex);
        playMusic.GetComponent<AudioSource>().volume = BGVol;

        //재생하고 있음 음악이 없을 때
        if (musicPlaying==false)
        {

            nowMusicindex = musicIndex;
            playMusic.GetComponent<AudioSource>().Play();
            musicPlaying = true;
        }
        //재생하고 있는 음악이 있을 때
        else
        {
            //현재 재생되고 있는 노래=플레이 버튼 누른 노래
            if(nowMusicindex==musicIndex)
            {
                
                playMusic.GetComponent<AudioSource>().Pause();
                musicPlaying = false;
            }
            //현재 재생되고 있는 노래!=플레이 버튼 누른 노래
            else
            {
                nowMusic = GameObject.Find("Song" + nowMusicindex);
                nowMusic.GetComponent<AudioSource>().Stop();
                playMusic.GetComponent<AudioSource>().Play();
                musicPlaying = true;
                nowMusicindex = musicIndex;
            }
        }
    }

    public void HeartChange()
    {
        GameObject clickButton = EventSystem.current.currentSelectedGameObject;
        
        if (clickButton.GetComponent<Image>().sprite==EmptyHeart)
        {
            clickButton.GetComponent<Image>().sprite = RedHeart;
        }
        else
        {
            clickButton.GetComponent<Image>().sprite = EmptyHeart;
        }
    }

    public void makePlaylist(InputField keyword)
    {
        GameManager.instance.playlistTitle = keyword.text;
        for(int i=0; i<10; i++)
        {
            if(musicLlkeList[i])
            {
                GameManager.instance.likeAlbumartList.Add(albumartList[i]);
            }
        }

        //씬 전환
        GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartAnimationDay5Scene();
    }
}
