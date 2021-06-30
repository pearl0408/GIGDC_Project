using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakePlaylist : MonoBehaviour
{
    public int musicNum;
    public bool[] musicLlkeList = new bool[9];
    GameObject howManyMusic;
    GameObject playMusic;
    bool musicPlaying;

    // Start is called before the first frame update
    void Start()
    {
        musicNum = 0;
        howManyMusic = GameObject.Find("HowManyMusic");
        musicPlaying = false;
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

        howManyMusic.GetComponent<Text>().text = "¥„¿∫ ∞Ó : " + musicNum + "∞≥";
    }

    public void MusicPlay(int musicIndex)
    {
        playMusic = GameObject.Find("Song" + musicIndex);
        if(musicPlaying==false)
        {
            playMusic.GetComponent<AudioSource>().Play();
            musicPlaying = true;
        }
        else
        {
            playMusic.GetComponent<AudioSource>().Pause();
            musicPlaying = false;
            Debug.Log("¿Ωæ« ∏ÿ√ﬂ±‚");
        }
    }
}
