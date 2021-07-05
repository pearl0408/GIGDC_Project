using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    //글자 버튼이 움직이는 스크립트
    private Rigidbody2D rigid;     //Rigidbody 컴포넌트를 가져올 변수
    private Transform myTransform;  //자신의 Transform 컴포넌트를 가져올 변수

    public float moveSpeed;    //버튼 움직임 속도(100~250 중 랜덤)
    int movementFlag = 0;   //움직임 신호 - 0:Idle, 1:Left, 2:Right, 3:Up, 4:Down

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();   //자신의 Rigidbody 컴포넌트를 가져옴
        myTransform = this.GetComponent<Transform>();   //자신의 Transform 컴포넌트를 가져옴

        StartCoroutine("ChangeFlag");   //움직임 신호 설정하는 코루틴 호출
    }

    void Update()
    {
        BtnMove();
    }

    void BtnMove()
    {
        Vector2 moveVelocity = Vector2.zero;    //움직임 속도 초기화

        //만약 지정 범위를 벗어나면 방향 뒤집음
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

        rigid.velocity = moveVelocity * moveSpeed;  //Btn 이동 
    }

    IEnumerator ChangeFlag()
    {
        movementFlag = Random.Range(0, 5);  //Btn 움직임 신호 랜덤 선택
        moveSpeed = Random.Range(100, 250);

        float randomWait = Random.Range(1, 5);  //1~5초 중 랜덤으로 기다림
        yield return new WaitForSeconds(randomWait);    //다음 동작까지 기다림

        StartCoroutine("ChangeFlag");   //코루틴 재호출
    }
}
