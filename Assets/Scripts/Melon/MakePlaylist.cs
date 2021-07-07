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

    //�׽�Ʈ��
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

        howManyMusic.GetComponent<Text>().text = "���� �� : " + musicNum + "��";
    }

    public void MusicPlay(int musicIndex)
    {
        playMusic = GameObject.Find("Song" + musicIndex);
        playMusic.GetComponent<AudioSource>().volume = BGVol;

        //����ϰ� ���� ������ ���� ��
        if (musicPlaying==false)
        {

            nowMusicindex = musicIndex;
            playMusic.GetComponent<AudioSource>().Play();
            musicPlaying = true;
        }
        //����ϰ� �ִ� ������ ���� ��
        else
        {
            //���� ����ǰ� �ִ� �뷡=�÷��� ��ư ���� �뷡
            if(nowMusicindex==musicIndex)
            {
                
                playMusic.GetComponent<AudioSource>().Pause();
                musicPlaying = false;
            }
            //���� ����ǰ� �ִ� �뷡!=�÷��� ��ư ���� �뷡
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

        //�� ��ȯ
        GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartAnimationDay5Scene();
    }
}
