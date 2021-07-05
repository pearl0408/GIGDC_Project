using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 함수: 게임 데이터를 관리

    public static GameManager instance; //싱글톤 패턴을 사용하기 위한 전역 변수

    public int saveDay; //마지막으로 저장된 에피소드 날짜
    public string playlistTitle;
    public ArrayList likeAlbumartList = new ArrayList();
    public string searchFood;   //검색한 음식
    public string orderFood;   //주문한 음식
    public string selectBook;   //선택한 책
    public string selectMovie;  //선택한 영화

    //시작과 동시에 싱글톤 구성
    void Awake()
    {
        //싱글톤 변수 instance가 이미 있다면
        if (instance)
        {
            DestroyImmediate(gameObject);   //삭제
        }

        instance = this;    //유일한 인스턴스로 만든다.
        DontDestroyOnLoad(gameObject);  //씬이 바뀌어도 계속 유지시킴

        //변수 초기화
        saveDay = PlayerPrefs.GetInt("SaveDay", 1);    //마지막으로 저장된 에피소드 회차를 가져옴. 만약 없다면 1을 가져옴.
    }
}
