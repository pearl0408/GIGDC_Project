using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    Color c, tc; //���� �ý�Ʈ Į��
    public Text message; //�ؽ�Ʈ
    
    //���̵� ��
    IEnumerator fadein()
    {
        for (float f = 0; f <= 1; f += 0.1f)
        {
            c = gameObject.GetComponent<Image>().color; //��� �̹��� �÷� �޾ƿ���
            tc= message.GetComponent<Text>().color; //�ؽ�Ʈ �̹��� �÷� �޾ƿ���          
            c.a = f; //���İ� ����
            tc.a = f; //���İ� ����
            message.GetComponent<Text>().color = tc; //�ٲ� ���İ� �����ϱ�(�ؽ�Ʈ)
            gameObject.GetComponent<Image>().color = c; //�ٲ� ���İ� �����ϱ�(���)

            yield return new WaitForSeconds(0.01f); //0.01�� ������
        }

        StartCoroutine(fadeout()); //���̵� �ƿ� ����

    }

    //���̵� �ƿ�
    IEnumerator fadeout()
    {
        yield return new WaitForSeconds(1.0f);

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            
            c = gameObject.GetComponent<Image>().color; //��� �̹��� �÷� �޾ƿ���
            tc = message.GetComponent<Text>().color; //�ؽ�Ʈ �̹��� �÷� �޾ƿ���
            c.a = f; //���İ� ����
            tc.a = f; //���İ� ����
            message.GetComponent<Text>().color = tc; //�ٲ� ���İ� �����ϱ�(�ؽ�Ʈ)
            gameObject.GetComponent<Image>().color = c; //�ٲ� ���İ� �����ϱ�(���)

            yield return new WaitForSeconds(0.01f); //0.01�� ������
        }

        gameObject.SetActive(false); //SetActive=false
    }

    //���ı��� Ŭ���ϸ� ����(��ư onClick)
    public void ToastButton1()
    {
        gameObject.SetActive(true); //SetActive=true
        //message = GameObject.Find("message"); //�ؽ�Ʈ ã��
        message.text = "���� ���� ����";  //�ؽ�Ʈ ����
        Vibration.Vibrate(100); // �����Լ�
        StartCoroutine(fadein()); //���̵� �� ����
    }

    public void ToastButton2()
    {
        gameObject.SetActive(true); //SetActive=true
        //message = GameObject.Find("message"); //�ؽ�Ʈ ã��
        message.text = "��޷� 20,000��";  //�ؽ�Ʈ ����
        Vibration.Vibrate(100); // �����Լ�
        StartCoroutine(fadein()); //���̵� �� ����
    }

    public void ToastButton3()
    {
        gameObject.SetActive(true); //SetActive=true
        //message = GameObject.Find("message"); //�ؽ�Ʈ ã��
        message.text = "���� 1.0";  //�ؽ�Ʈ ����
        Vibration.Vibrate(100); // �����Լ�
        StartCoroutine(fadein()); //���̵� �� ����
    }
}
