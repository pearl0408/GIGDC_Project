using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManage : MonoBehaviour
{
    public AudioSource BGAudio; //배경음악 오디오

    //오브젝트 변수
    public Slider BGSlider; //배경 슬라이더
    public Slider EFSlider; //효과음 슬라이더
    public Toggle VibOff;   //진동 토글

    //오디오 크기값
    private float BGVol;
    private float EFVol;

    //private bool isVibOff;   //진동이 꺼져있는지 확인하는 변수

 
    void Start()
    {
     
        // PlayerPrefs에 저장된 값을 가져옴(값이 비었다면 1을 가져옴)
        BGVol = PlayerPrefs.GetFloat("BGVol", 1f);
        EFVol = PlayerPrefs.GetFloat("EFVol", 1f);
        Vibration.isVibOff = PlayerPrefs.GetInt("isVibOff", 0) == 1;

        //저장된 값을 반영함
        BGSlider.value = BGVol;
        EFSlider.value = EFVol;
        VibOff.isOn = Vibration.isVibOff == true ? true : false;

        //슬라이더의 값을 시작화면 배경음악 오디오에 반영함
        BGAudio.volume = BGSlider.value;
    }

    //BackGround Sound 조절 함수
    public void BGSoundSlider()
    {
        //슬라이더의 값을 시작화면 배경음악 오디오에 반영함
        BGAudio.volume = BGSlider.value;

        //값을 유지하기 위해 float형 변수에 넣은 후 PlayerPrefs()를 이용하여 저장함
        BGVol = BGSlider.value;
        PlayerPrefs.SetFloat("BGVol", BGVol);
    }

    //Effect Sound 조절 함수
    public void EFSoundSlider()
    {
        //값을 유지하기 위해 float형 변수에 넣은 후 PlayerPrefs()를 이용하여 저장함
        EFVol = EFSlider.value;
        PlayerPrefs.SetFloat("EFVol", EFVol);
    }

    //진동 조절 함수
    public void VibrateToggle()
    {
        //값을 유지하기 위해 bool 변수에 넣은 후 PlayerPrefs()을 이용하여 저장함
        Vibration.isVibOff = VibOff.isOn;
        int onoff = Vibration.isVibOff == true ? 1 : 0;
        PlayerPrefs.SetInt("isVibOff", onoff);
    }
}
