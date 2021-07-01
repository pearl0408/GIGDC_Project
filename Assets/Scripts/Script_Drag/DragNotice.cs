using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
            Debug.Log(startPos);
            this.startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.y - this.startPos.y;
            Debug.Log(endPos);

            if (swipeLength > 5)
            {
                StartCoroutine(swipe(1));
                Debug.Log("5보다 큼");
            }
            else if (swipeLength < -5)
            {
                StartCoroutine(swipe(-1));
                Debug.Log("5보다 작음");
            }
        }
    }

    IEnumerator swipe(int j)
    {
        for(int i=0; i<50; i++)
        {
            transform.Translate(0, 50*j, 0);
            yield return new WaitForSeconds(0.01f); //0.01초 딜레이
        }
    }
}
