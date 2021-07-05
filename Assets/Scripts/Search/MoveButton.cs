using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    //���� ��ư�� �����̴� ��ũ��Ʈ
    private Rigidbody2D rigid;     //Rigidbody ������Ʈ�� ������ ����
    private Transform myTransform;  //�ڽ��� Transform ������Ʈ�� ������ ����

    public float moveSpeed;    //��ư ������ �ӵ�(100~250 �� ����)
    int movementFlag = 0;   //������ ��ȣ - 0:Idle, 1:Left, 2:Right, 3:Up, 4:Down

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();   //�ڽ��� Rigidbody ������Ʈ�� ������
        myTransform = this.GetComponent<Transform>();   //�ڽ��� Transform ������Ʈ�� ������

        StartCoroutine("ChangeFlag");   //������ ��ȣ �����ϴ� �ڷ�ƾ ȣ��
    }

    void Update()
    {
        BtnMove();
    }

    void BtnMove()
    {
        Vector2 moveVelocity = Vector2.zero;    //������ �ӵ� �ʱ�ȭ

        //���� ���� ������ ����� ���� ������
        if (myTransform.position.x < 200f)
        {
            movementFlag = 2;
        }
        else if (myTransform.position.x > 900f)
        {
            movementFlag = 1;
        }
        else if (myTransform.position.y < 350f)
        {
            movementFlag = 4;
        }
        else if (myTransform.position.y > 850)
        {
            movementFlag = 3;
        }

        switch (movementFlag)
        {
            case 0:
                moveVelocity = Vector2.zero; break;
            case 1:
                moveVelocity = Vector2.left; break;
            case 2:
                moveVelocity = Vector2.right; break;
            case 3:
                moveVelocity = Vector2.down; break;
            case 4:
                moveVelocity = Vector2.up; break;
            default:
                moveVelocity = Vector2.zero; break;

        }

        rigid.velocity = moveVelocity * moveSpeed;  //Btn �̵� 
    }

    IEnumerator ChangeFlag()
    {
        movementFlag = Random.Range(0, 5);  //Btn ������ ��ȣ ���� ����
        moveSpeed = Random.Range(100, 250);

        float randomWait = Random.Range(1, 5);  //1~5�� �� �������� ��ٸ�
        yield return new WaitForSeconds(randomWait);    //���� ���۱��� ��ٸ�

        StartCoroutine("ChangeFlag");   //�ڷ�ƾ ��ȣ��
    }
}
