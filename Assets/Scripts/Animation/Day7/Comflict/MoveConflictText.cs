using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConflictText : MonoBehaviour
{
    private Transform myTransform;
    Vector3 upVelocity;

    private float moveSpeed;  //움직임 속도
    private int flow;   //싸움 횟수

    void Start()
    {
        myTransform = this.GetComponent<Transform>();
        upVelocity = Vector3.up;

        flow = this.gameObject.transform.parent.gameObject.GetComponent<TypingAnswer>().conflictFlow;   //흐름 횟수를 가져옴
        flowSpeed(flow);
    }

    void Update()
    {
        myTransform.position += upVelocity * moveSpeed * Time.deltaTime; //말풍선 위치 위로 이동

        if (myTransform.position.y > 1500f)     //1500f 위치에 도달하면
        {
            Destroy(this.gameObject);  //자기 자신을 삭제
        }
    }

    //움직임 빠르기 조절
    public void flowSpeed(int flow)
    {
        switch (flow)
        {
            case 0:
                moveSpeed = 50f; break;
            case 1:
                moveSpeed = 60f; break;
            case 2:
                moveSpeed = 70f; break;
            case 3:
                moveSpeed = 80f; break;
            case 4:
                moveSpeed = 90f; break;
            case 5:
                moveSpeed = 100f; break;
            case 6:
                moveSpeed = 110f; break;
            case 7:
                moveSpeed = 120f; break;
        }
    }
}
