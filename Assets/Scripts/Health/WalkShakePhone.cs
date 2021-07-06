using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WalkShakePhone : MonoBehaviour
{
    public GameObject phone;
    public GameObject walkNum;
    public GameObject success;
    
    Vector2 moveVelocity;
    int walkNumText;

    private bool isShaking; //움직이고 있는지

    // Start is called before the first frame update
    void Start()
    {
        isShaking = false;

        walkNumText = 0;
        
        
        walkNum = GameObject.Find("WalkNum");
        moveVelocity = new Vector2(0, 1.0f);
        success = GameObject.Find("Success");
        success.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        if (!isShaking)
        {
            isShaking = true;

            walkNumText += 500;
            walkNum.GetComponent<Text>().text = walkNumText.ToString();

            if (walkNumText == 6000)
            {
                //씬 전환
                Debug.Log("애니메이션 전환");
                success.SetActive(true);
            }

            moveVelocity = new Vector2(0, 1.0f);

            StartCoroutine(updown());
            isShaking = false;
        }
    }

    IEnumerator updown()
    {
        //위로
        for (float f = 0; f <= 1; f += 0.2f)
        {
            phone.transform.Translate(moveVelocity * 10.0f * Time.deltaTime);
            this.transform.Translate(moveVelocity * 10.0f * Time.deltaTime);

            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

        //아래로
        for (float f = 0; f <= 1; f += 0.2f)
        {
            phone.transform.Translate(-1.0f*moveVelocity * 10.0f * Time.deltaTime);
            this.transform.Translate(-1.0f * moveVelocity * 10.0f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

        StartCoroutine(downup());
        yield return null;
    }

    IEnumerator downup()
    {
        //아래로
        for (float f = 0; f <= 1; f += 0.2f)
        {
            phone.transform.Translate(-1.0f * moveVelocity * 10.0f * Time.deltaTime);
            this.transform.Translate(-1.0f * moveVelocity * 10.0f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

        //위로
        for (float f = 0; f <= 1; f += 0.2f)
        {
            phone.transform.Translate(moveVelocity * 10.0f * Time.deltaTime);
            this.transform.Translate(moveVelocity * 10.0f * Time.deltaTime);

            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

        yield return null;
    }
}
