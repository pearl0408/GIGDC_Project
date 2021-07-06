using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetalManager : MonoBehaviour
{
    //꽃잎이 흩날리는 애니메이션
    public Sprite[] petals; //꽃잎 스프라이트
    public Image petalObject;   //꽃잎 오브젝트(이미지)

    void Start()
    {
        //시작하면 꽃잎 생성(기본 5개 생성되어 있음)
        StartCoroutine("CreatePetals");
    }

    //랜덤초마다 꽃잎을 생성하는 코루틴 함수
    IEnumerator CreatePetals()
    {
        int randomX = Random.Range(370, 450);
        int randomY = Random.Range(450, 700);
        Image petal = (Image)Instantiate(petalObject, new Vector3(randomX, randomY, 0), Quaternion.identity);   //랜덤 좌표에 꽃잎 생성
        petal.transform.SetParent(this.transform);    //이 오브젝트의 자식 오브젝트로 생성

        int randomImg = Random.Range(0, 5);
        petal.sprite = petals[randomImg];


        float randomSec = Random.Range(1.2f, 1.5f);
        yield return new WaitForSeconds(randomSec);    //랜덤초 후
        StartCoroutine("CreatePetals");
    }
}
