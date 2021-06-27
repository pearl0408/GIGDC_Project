using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkShakePhone : MonoBehaviour
{
    public GameObject phone;
    
    Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        phone = GameObject.Find("Phone");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        moveVelocity = new Vector2(0, 1.0f);

        StartCoroutine(updown()); //페이드 인 시작
    }

    IEnumerator updown()
    {
        //위로
        for (float f = 0; f <= 1; f += 0.02f)
        {
            phone.transform.Translate(moveVelocity * 400.0f * Time.deltaTime);
            this.transform.Translate(moveVelocity * 400.0f * Time.deltaTime);

            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

        //아래로
        for (float f = 0; f <= 1; f += 0.02f)
        {
            phone.transform.Translate(-1.0f*moveVelocity * 400.0f * Time.deltaTime);
            this.transform.Translate(-1.0f * moveVelocity * 400.0f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

    }
}
