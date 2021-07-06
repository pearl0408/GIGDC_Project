using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetalManager : MonoBehaviour
{
    //������ �𳯸��� �ִϸ��̼�
    public Sprite[] petals; //���� ��������Ʈ
    public Image petalObject;   //���� ������Ʈ(�̹���)

    void Start()
    {
        //�����ϸ� ���� ����(�⺻ 5�� �����Ǿ� ����)
        StartCoroutine("CreatePetals");
    }

    //�����ʸ��� ������ �����ϴ� �ڷ�ƾ �Լ�
    IEnumerator CreatePetals()
    {
        int randomX = Random.Range(370, 450);
        int randomY = Random.Range(450, 700);
        Image petal = (Image)Instantiate(petalObject, new Vector3(randomX, randomY, 0), Quaternion.identity);   //���� ��ǥ�� ���� ����
        petal.transform.SetParent(this.transform);    //�� ������Ʈ�� �ڽ� ������Ʈ�� ����

        int randomImg = Random.Range(0, 5);
        petal.sprite = petals[randomImg];


        float randomSec = Random.Range(1.2f, 1.5f);
        yield return new WaitForSeconds(randomSec);    //������ ��
        StartCoroutine("CreatePetals");
    }
}
