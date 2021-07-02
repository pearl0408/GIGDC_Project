using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Unlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 startPosition;
    Vector2 endPosition;

    public GameObject unlockPanel;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        unlockPanel = GameObject.Find("Panel_Lock");
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown)
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //startPosition = eventData.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if(eventData.position.x>startPosition.x)
        {
            transform.position = new Vector2(eventData.position.x, transform.position.y);   
            //Debug.Log(eventData.position.x);
        }
        if(eventData.position.x>770)
        {
            unlockPanel.SetActive(false);
            //Debug.Log("hey");
        }
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(eventData.position.x<770)
        {
            endPosition = eventData.position;
            float distance = endPosition.x - startPosition.x;
            StartCoroutine(reposition(distance));
        }
    }

    IEnumerator reposition(float distance)
    {
        Debug.Log("µÈæÓø»");
        while(transform.position.x>startPosition.x)
        {
            Debug.Log(transform.position.x);
            transform.Translate(-20, 0, 0);
            yield return new WaitForSeconds(0.01f); //0.01√  µÙ∑π¿Ã
        }
    }
}
