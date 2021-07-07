using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMovie : MonoBehaviour
{
    //영화를 선택하는 함수
    public movies thisMovie;

    public void SelectThisMovie()
    {
        GameManager.instance.selectMovie = thisMovie.ToString();    //고른 영화 저장
        PlayerPrefs.SetString("SelectMovie", thisMovie.ToString());
        GameObject.FindWithTag("GameSystem").GetComponent<SceneChange>().StartAnimationDay3Scene(); //씬 전환
    }
}
