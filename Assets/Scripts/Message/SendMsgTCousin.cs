using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTCousin : MonoBehaviour
{
    public Button touchPanel; // ȭ�� ��ġ ����
    public int Cnt; // ȭ�� ��ġ Ƚ�� 
    public GameObject Msg1, Msg2, Msg3; // �޼���

    // Start is called before the first frame update
    void Start()
    {
        Cnt = 0; // Ƚ�� 0������ ����
        touchPanel.onClick.AddListener(touchOnce); // ��ġ �۵��ϰ� �ϴ� �Լ�
    }

    IEnumerator touchCnt()
    {
        Cnt++;

        if(Cnt == 1)
         {
            Msg1.SetActive(true);
        }
        if (Cnt == 2)
        {
            Msg2.SetActive(true);
         }
        if (Cnt == 3)
        {
            Msg3.SetActive(true);
        }
        if (Cnt == 4)
        {
            Destroy(gameObject);
        }
        

       yield return new WaitForSeconds(0.01f); //0.01�� ������

    }

    public void touchOnce()
    {
        StartCoroutine(touchCnt());
    }

}
