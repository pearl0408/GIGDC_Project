using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAlarmTalk : MonoBehaviour
{
    public void alarmTalk()
    {
        Vibration.Vibrate(100); // ���� �Լ�
        //this.GetComponent<AudioSource>().Play();
        StartCoroutine(downAndup());
    }

    IEnumerator downAndup()
    {
        yield return new WaitForSeconds(0.5f); //0.01�� ������

        while (transform.position.y>1500)
        {           
            transform.Translate(0, -10, 0);
            yield return new WaitForSeconds(0.01f); //0.01�� ������
        }

        yield return new WaitForSeconds(2.0f);

        while (transform.position.y < 1800)
        {
            transform.Translate(0, 10, 0);
            yield return new WaitForSeconds(0.01f); //0.01�� ������
        }

        gameObject.SetActive(false);
    }
}
