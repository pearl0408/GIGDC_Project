using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManage : MonoBehaviour
{
    public AudioSource BGAudio; //������� �����

    //������Ʈ ����
    public Slider BGSlider; //��� �����̴�
    public Slider EFSlider; //ȿ���� �����̴�
    public Toggle VibOff;   //���� ���

    //����� ũ�Ⱚ
    private float BGVol;
    private float EFVol;

    //private bool isVibOff;   //������ �����ִ��� Ȯ���ϴ� ����

 
    void Start()
    {
     
        // PlayerPrefs�� ����� ���� ������(���� ����ٸ� 1�� ������)
        BGVol = PlayerPrefs.GetFloat("BGVol", 1f);
        EFVol = PlayerPrefs.GetFloat("EFVol", 1f);
        Vibration.isVibOff = PlayerPrefs.GetInt("isVibOff", 0) == 1;

        //����� ���� �ݿ���
        BGSlider.value = BGVol;
        EFSlider.value = EFVol;
        VibOff.isOn = Vibration.isVibOff == true ? true : false;

        //�����̴��� ���� ����ȭ�� ������� ������� �ݿ���
        BGAudio.volume = BGSlider.value;
    }

    //BackGround Sound ���� �Լ�
    public void BGSoundSlider()
    {
        //�����̴��� ���� ����ȭ�� ������� ������� �ݿ���
        BGAudio.volume = BGSlider.value;

        //���� �����ϱ� ���� float�� ������ ���� �� PlayerPrefs()�� �̿��Ͽ� ������
        BGVol = BGSlider.value;
        PlayerPrefs.SetFloat("BGVol", BGVol);
    }

    //Effect Sound ���� �Լ�
    public void EFSoundSlider()
    {
        //���� �����ϱ� ���� float�� ������ ���� �� PlayerPrefs()�� �̿��Ͽ� ������
        EFVol = EFSlider.value;
        PlayerPrefs.SetFloat("EFVol", EFVol);
    }

    //���� ���� �Լ�
    public void VibrateToggle()
    {
        //���� �����ϱ� ���� bool ������ ���� �� PlayerPrefs()�� �̿��Ͽ� ������
        Vibration.isVibOff = VibOff.isOn;
        int onoff = Vibration.isVibOff == true ? 1 : 0;
        PlayerPrefs.SetInt("isVibOff", onoff);
    }
}
