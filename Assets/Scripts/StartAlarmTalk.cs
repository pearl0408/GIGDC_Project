using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAlarmTalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void alarmTalk()
    {
        StartCoroutine(downAndup());
    }

    IEnumerator downAndup()
    {
        yield return new WaitForSeconds(0.5f); //0.01√  µÙ∑π¿Ã

        while (transform.position.y>1500)
        {           
            transform.Translate(0, -10, 0);
            yield return new WaitForSeconds(0.01f); //0.01√  µÙ∑π¿Ã
        }

        yield return new WaitForSeconds(2.0f);

        while (transform.position.y < 1800)
        {
            transform.Translate(0, 10, 0);
            yield return new WaitForSeconds(0.01f); //0.01√  µÙ∑π¿Ã
        }

        gameObject.SetActive(false);
    }
}
