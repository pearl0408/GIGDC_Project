using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConflictText : MonoBehaviour
{
    private Transform myTransform;
    Vector3 upVelocity;

    private float moveSpeed;  //������ �ӵ�
    private int flow;   //�ο� Ƚ��

    void Start()
    {
        myTransform = this.GetComponent<Transform>();
        upVelocity = Vector3.up;

        flow = this.gameObject.transform.parent.gameObject.GetComponent<TypingAnswer>().conflictFlow;   //�帧 Ƚ���� ������
        flowSpeed(flow);
    }

    void Update()
    {
        myTransform.position += upVelocity * moveSpeed * Time.deltaTime; //��ǳ�� ��ġ ���� �̵�

        if (myTransform.position.y > 1500f)     //1500f ��ġ�� �����ϸ�
        {
            Destroy(this.gameObject);  //�ڱ� �ڽ��� ����
        }
    }

    //������ ������ ����
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
