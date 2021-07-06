using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectInDM : MonoBehaviour
{
    int Cnt; // ȭ�� ��ġ Ƚ�� 
    public Button tocuhPanel; // ȭ�� ��ġ ����
    public GameObject Msg1, Msg2, Msg3, Msg4; // �޼���
    public GameObject selectPanel; // ��ġ ���� ����
    public Button btn1, btn2, btn3; // ��ġ ���� ��ư 
    public GameObject Msg3Txt; // ���� �޼���
    public GameObject blockPanel; // ���� �г� �� ���� ��ġ�� ���� ���� ��� �г�

    // Start is called before the first frame update
    void Start()
    {
        Cnt = 0;
        tocuhPanel.onClick.AddListener(touchOnce); // ��ġ �۵��ϰ� �ϴ� �Լ�
    }

    // ��ġ �ڷ�ƾ �۵� ����
    public void touchOnce()
    {
        Vibration.Vibrate(100); // ���� �Լ�
        StartCoroutine(touchCnt());
    }

    IEnumerator touchCnt()
    {
        Cnt++;

        // msg1 ���̱�
        if (Cnt == 1)
        {
            Msg1.SetActive(true);
        }
        // msg2 ���̱�
        if (Cnt == 2)
        {
            Msg2.SetActive(true);
        }
        // msg3 ���̱�
        if (Cnt == 3)
        {
            Msg3.SetActive(true);
        }
        // ���� �г� ���̱� 
        if (Cnt == 4)
        {
            //��� �г� ���̱� 
            blockPanel.SetActive(true);
            // ���� �ڷ�ƾ ���� 
            selectPanel.SetActive(true);
            StartCoroutine(showQuizPanel());

        }
      

        yield return new WaitForSeconds(0.01f); //0.01�� ������

    }

    // ���� �ڷ�ƾ �Լ� 
    IEnumerator showQuizPanel()
    {
        // ���� ���� ��
        btn1.onClick.AddListener(wrongClicked);

        btn3.onClick.AddListener(wrongClicked);

        // ���� ���� �� 
        btn2.onClick.AddListener(correctClicked);

        yield return new WaitForSeconds(0.01f); //0.01�� ������
    }

    // ���� Ŭ�� �� ��ư �̺�Ʈ
    public void wrongClicked()
    {
        Vibration.Vibrate(200); // ���� �Լ�
    }

    // ���� Ŭ�� �� ��ư �̺�Ʈ 
    public void correctClicked()
    {
        Object.Destroy(blockPanel);//  ��� �г� ���ֱ� 
        Object.Destroy(selectPanel);// ���� �г� ���ֱ�
        Msg3Txt.SetActive(true); // ���� �޼��� �����ֱ�

        StartCoroutine(showFinalMsg());
  
    }

    IEnumerator showFinalMsg()
    {
        yield return new WaitForSeconds(1f); //3�� ������
        Msg4.SetActive(true);


        yield return new WaitForSeconds(2f); //3�� ������
        Destroy(gameObject);  // touchPanel ���ֱ�
    }

}
