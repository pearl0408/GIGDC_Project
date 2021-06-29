using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakePlaylist : MonoBehaviour
{
    public int musicNum;
    public bool[] musicLlkeList = new bool[9];
    GameObject howManyMusic;

    // Start is called before the first frame update
    void Start()
    {
        musicNum = 0;
        howManyMusic = GameObject.Find("HowManyMusic");
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
}
