using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OpeningAnimation : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("����");
        transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * Input.GetAxis("Mouse Y") * speed);
        //transform.Rotate(-Input.GetAxis("Mouse Y") , 0f, 0f);

        //var dir = new Vector3(eventData.position.x, eventData.position.y, 0) - Camera.main.WorldToScreenPoint(transform.position);//���콺 ���� ����ϱ�
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//ȸ���� ����ϱ�
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//ȭ��ǥ ȸ���� �ٲٱ�
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }
}
