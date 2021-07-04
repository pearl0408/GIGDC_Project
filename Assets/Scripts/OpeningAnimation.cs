using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OpeningAnimation : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private float speed = 3f;
    public GameObject minute;
    Transform startAngle;

    // Start is called before the first frame update
    void Start()
    {
        startAngle = minute.transform;
        var startAngledd = startAngle.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {

    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("들어옴");
        //transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * Input.GetAxis("Mouse Y") * speed);
        //transform.Rotate(-Input.GetAxis("Mouse Y") , 0f, 0f);

        var dir = new Vector3(eventData.position.x, eventData.position.y, 0) - minute.transform.position;//마우스 방향 계산하기
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//회전각 계산하기
        minute.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//화살표 회전각 바꾸기
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }
}
