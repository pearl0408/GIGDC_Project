using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingAnswer : MonoBehaviour
{
    //�÷��̾ ������ �亯�� Ÿ�����ϰ�, ������ ��簡 Ÿ�������� ��µǴ� Ŭ����
    public GameObject nextPanel;
    public GameObject mom_Message;  //������ ���
    public GameObject player_Message;  //���ΰ��� ���
    public GameObject playerAnswerPanel; //�÷��̾� ��� ���� ��ư
    public Image BG;    //��� �̹���
    public GameObject breakLine;    //���� �̹���
    public GameObject bgm;

    public Image mom_Image;   //���� �̹���
    public Image player_Image;    //���ΰ� �̹���

    Text mom_Text;  //������ �ؽ�Ʈ
    Text player_Text;   //�÷��̾��� �ؽ�Ʈ

    private float typingSpeed = 0.2f;  //Ÿ���� �ӵ�
    private float waitSpeed = 2f;  //��ȭâ ��

    Color currentColor = new Color(1f, 1f, 1f, 1f); //���� ��� ����
    Color changeColor;  //�ٲ� ��� ����

    public string[] momAnswerList = { "�츮 ���� �� �׷���!" , "������ ���� ����, �а��鼭 ���� ������",
        "��� ���� �� ������", "���� ���￡�� ��ó���� �ž�", "�и� �׷��� ���� �����Ұ�",
        "���߿� �� ���� �Ⱦ����� ��ҷ�?", "���߿� �츮 ſ���� ����" };  //������ ��� ����Ʈ

    public int conflictFlow;   //���� �帧

    void Start()
    {
        //mom_Text = mom_Message.gameObject.transform.GetChild(0).gameObejct.GetComponent<Text>();   //�ؽ�Ʈ�� ������
        //player_Text = player_Message.gameObject.transform.GetChild(0).gameObejct.GetComponent<Text>(); //�ؽ�Ʈ�� ������
        bgm.GetComponent<AudioSource>().Play();
        conflictFlow = 0;   //���� �帧
        breakLine.gameObject.SetActive(false);
        //���� ����
        StartCoroutine(momTyping(mom_Message, momAnswerList[conflictFlow]));
    }

    //

    //���� �޽��� Ÿ���� �Լ�
    IEnumerator momTyping(GameObject talker_Message, string message)
    {
        waitTermSpeed(conflictFlow);
        yield return new WaitForSeconds(waitSpeed);

        GameObject mom_Message = (GameObject)Instantiate(talker_Message, new Vector2(600f, 1200f), Quaternion.identity);    //��ǳ�� ����
        mom_Message.gameObject.transform.SetParent(this.gameObject.transform); //���� ������Ʈ�� �ڽ� ������Ʈ�� ����

        mom_Text = mom_Message.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();   //�ؽ�Ʈ�� ������

        flowSpeed(conflictFlow);    //������ ����
        changeBGColor(conflictFlow);    //��� ���� ����

        //�޽��� Ÿ����
        for (int i = 0; i < message.Length; i++)
        {
            mom_Text.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //�÷��̾� �޽��� Ÿ���� �Լ�
    IEnumerator playerTyping(GameObject talker_Message, string message)
    {
        GameObject player_Message = (GameObject)Instantiate(talker_Message, new Vector2(500f, 1000f), Quaternion.identity);    //��ǳ�� ����
        player_Message.gameObject.transform.SetParent(this.gameObject.transform); //���� ������Ʈ�� �ڽ� ������Ʈ�� ����

        player_Text = player_Message.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>(); //�ؽ�Ʈ�� ������

        flowSpeed(conflictFlow);    //������ ����

        //�޽��� Ÿ����
        for (int i = 0; i < message.Length; i++)
        {
            player_Text.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(typingSpeed);
        }

        if (conflictFlow == 7)  //��ȭ�� �����ٸ�(�� �̵�)
        {
            playerAnswerPanel.gameObject.SetActive(false);

            //������ ���ΰ� ���� ����
            breakLine.gameObject.SetActive(true);

            //������ ���ΰ� �� ����
            mom_Image.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            player_Image.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);

            nextPanel.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            //Ÿ������ ������ ���� �޼��� Ÿ����
            currentColor = BG.color;
            StartCoroutine(momTyping(mom_Message, momAnswerList[conflictFlow]));
        }
    }

    //��ư ���� �Լ�(��ư Ŭ�� �̺�Ʈ�� ���� ��)
    public void selectAnswer()
    {
        string selectText = playerAnswerPanel.gameObject.GetComponent<SelectAnswerConflict>().returnAnswerText();    //�÷��̾ ������ �亯�� ������

        bool isCorrect = checkCorrectAnswer(selectText); //����� ��ġ�ϴ��� Ȯ��
        if (isCorrect)  //�����̶��
        {
            StartCoroutine(playerTyping(player_Message, selectText)); //�÷��̾� �亯 Ÿ����
            conflictFlow++; //��ȭ �帧 1 ����
        }
        else
        { // �����̸� ����
            Vibration.Vibrate(100); // ����
        }
    }

    //�÷��̾ ������ �ؽ�Ʈ�� ����� ��ġ�ϴ��� Ȯ���ϴ� �Լ�
    public bool checkCorrectAnswer(string selectText)
    {
        bool result;

        if (conflictFlow == 0 && selectText == "������ �ô밡 �޶��")
        {
            result = true;
        }
        else if (conflictFlow == 1 && selectText == "���� �ູ���� ���� �ɿ�")
        {
            result = true;
        }
        else if (conflictFlow == 2 && selectText == "�̷��� ��� ���� �ʾƿ�")
        {
            result = true;
        }
        else if (conflictFlow == 3 && selectText == "������� �� ���帶�� �����")
        {
            result = true;
        }
        else if (conflictFlow == 4 && selectText == "�λ��� ��� ���а� �����")
        {
            result = true;
        }
        else if (conflictFlow == 5 && selectText == "�ٸ� �� ã���� ����")
        {
            result = true;
        }
        else if (conflictFlow == 6 && selectText == "�� �λ��̴� ���� �����ϰ� �����ϰ� �̰ܳ� �ſ���")
        {
            result = true;
        }
        else
        {
            result = false;
        }

        return result;
    }

    //Ÿ���� ������ ����
    public void flowSpeed(int flow)
    {
        switch (flow)
        {
            case 0:
                typingSpeed = 0.2f; break;
            case 1:
                typingSpeed = 0.17f; break;
            case 2:
                typingSpeed = 0.15f; break;
            case 3:
                typingSpeed = 0.13f; break;
            case 4:
                typingSpeed = 0.1f; break;
            case 5:
                typingSpeed = 0.08f; break;
            case 6:
                typingSpeed = 0.05f; break;
        }
    }


    //Ÿ���� ������ ����
    public void waitTermSpeed(int flow)
    {
        switch (flow)
        {
            case 0:
                waitSpeed = 2f; break;
            case 1:
                waitSpeed = 2f; break;
            case 2:
                waitSpeed = 1.8f; break;
            case 3:
                waitSpeed = 1.8f; break;
            case 4:
                waitSpeed = 1.5f; break;
            case 5:
                waitSpeed = 1.3f; break;
            case 6:
                waitSpeed = 1f; break;
        }
    }

    //��� ���� ����
    public void changeBGColor(int flow)
    {
        switch (flow)
        {
            case 0:
                BG.color = Color.white; break;
            case 1:
                changeColor = new Color(1f, 0.9f, 0.9f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 2:
                changeColor = new Color(1f, 0.8f, 0.8f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 3:
                changeColor = new Color(1f, 0.65f, 0.65f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 4:
                changeColor = new Color(1f, 0.5f, 0.5f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 5:
                changeColor = new Color(1f, 0.25f, 0.25f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
            case 6:
                changeColor = new Color(1f, 0f, 0f, 1f);
                BG.color = Color.Lerp(currentColor, changeColor, 3f); break;
        }
    }
}
