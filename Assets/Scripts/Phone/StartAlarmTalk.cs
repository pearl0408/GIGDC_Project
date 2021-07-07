using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAlarmTalk : MonoBehaviour
{
    public void alarmTalk()
    {
        Vibration.Vibrate(100); // 진동 함수
        //this.GetComponent<AudioSource>().Play();
        StartCoroutine(downAndup());
    }

    IEnumerator downAndup()
    {
        yield return new WaitForSeconds(0.5f); //0.01초 딜레이

        while (transform.position.y>1500)
        {           
            transform.Translate(0, -10, 0);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        yield return new WaitForSeconds(2.0f);

        while (transform.position.y < 1800)
        {
            transform.Translate(0, 10, 0);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }

        gameObject.SetActive(false);
    }
}
