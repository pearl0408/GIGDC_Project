using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragNotice : MonoBehaviour
{
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {           
            this.startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.y - this.startPos.y;           

            //위로 스와이프
            if (startPos.y > 299 && startPos.y < 330 && swipeLength > 10 && transform.position.y < 1000)
            {
                StartCoroutine(swipe(1));
                
            }
            //아래로 스와이프
            else if (startPos.y > 1592 && startPos.y < 1660 && swipeLength < -10 && transform.position.y > 1000)
            {
                StartCoroutine(swipe(-1));               
            }
        }
    }

    IEnumerator swipe(int j)
    {
        for(int i=0; i<30; i++)
        {
            transform.Translate(0, 50*j, 0);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }
    }
}
