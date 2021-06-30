using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMsgTCousin : MonoBehaviour
{
    public Button touchPanel;
    public int Cnt;
    public GameObject Msg1, Msg2, Msg3;

    // Start is called before the first frame update
    void Start()
    {
        Cnt = 0;
        touchPanel.onClick.AddListener(touchOnce);
    }

    IEnumerator touchCnt()
    {
        Cnt++;

        if(Cnt == 1)
         {
            Debug.Log("문자1 터치");
            Msg1.SetActive(true);
        }
        if (Cnt == 2)
        {
            Debug.Log("문자2 터치");
            Msg2.SetActive(true);
         }
        if (Cnt == 3)
        {
            Debug.Log("문자3 터치");
            Msg3.SetActive(true);
        }
        if (Cnt == 4)
        {
            Destroy(gameObject);
        }
        

       yield return new WaitForSeconds(0.01f); //0.01초 딜레이

    }

    public void touchOnce()
    {
        StartCoroutine(touchCnt());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
