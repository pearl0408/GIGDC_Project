using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAlarmScreen : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject alarmPanel;
    //public RectTransform rectTransform;
  
    public void OnBeginDrag(PointerEventData eventData)
    {
        alarmPanel = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPosition = new Vector2(transform.position.x,Input.mousePosition.y);
        transform.position = touchPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RectTransform trans = transform.gameObject.GetComponent<RectTransform>();
        //float yMoved = eventData.position.y - rectTransform.position.y;
        float yMoved = Input.mousePosition.y - eventData.position.y;
        float distance = Mathf.Sqrt(yMoved * yMoved);

        if (distance > 50f)
        {
            if (yMoved > 0)
            {
                alarmPanel.transform.Translate(3, 65, 0);
                //trans.anchoredPosition = new Vector2(transform.position.x, 600);
                //trans.anchoredPosition = vector;
                //transform.position = new Vector2(transform.position.x, 65);
                // 위로 드래그 
                //rectTransform.transform.Translate(0, 0, 0);

            }
            if (yMoved < 0)
            {
                alarmPanel.transform.Translate(3, -200, 0);
                //trans.anchoredPosition = new Vector2(transform.position.x, -600);
                //trans.anchoredPosition = vector;
                //transform.position = new Vector2(transform.position.x, -600);
            }
        }
        //if (rectTransform.anchoredPosition.y < 0 && swipedLeft == false)
        //{
            //아래로 드래그
            // rectTransform.transform.Translate(0, -900, 0);
        //}

    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
}
