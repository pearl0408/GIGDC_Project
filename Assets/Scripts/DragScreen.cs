using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScreen : MonoBehaviour
{
    public GameObject alarmPanel;
    public Touch initTouch;
    bool swiped = false;

    void Start()
    {
        StartCoroutine(DragUpAndDown());
    }

    IEnumerator DragUpAndDown()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                initTouch = t;

            }
            else if (t.phase == TouchPhase.Moved && !swiped)
            {
                float xMoved = initTouch.position.x - t.position.x;
                float yMoved = initTouch.position.y - t.position.y;
                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));
                bool swipedLeft = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                if (distance > 50f)
                {
                    if (swipedLeft == false && yMoved > 0)
                    {
                        alarmPanel.transform.Translate(0, -100, 0);
                        // 위로 드래그
                    }
                    else if (swipedLeft == false && yMoved < 0)
                    {
                        alarmPanel.transform.Translate(0, 100, 0);
                        //아래로 드래그
                    }

                    swiped = true;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
                swiped = false;
            }

        }
        yield return new WaitForSeconds(0.01f); //0.01초 딜레이
    }
}

