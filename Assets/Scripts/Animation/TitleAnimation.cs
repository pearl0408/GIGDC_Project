using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{
    //������ �𳯸��� �ִϸ��̼�
    public Sprite[] petals; //���� ��������Ʈ
    public Image petalObject;   //���� ������Ʈ(�̹���)

    void Start()
    {
        //�����ϸ� ���� ����(�⺻ 5�� �����Ǿ� ����)
        StartCoroutine("CreatePetals");
    }

    //1�ʸ��� ������ �����ϴ� �ڷ�ƾ �Լ�
    IEnumerator CreatePetals()
    {
        int randomX = Random.Range(-187, -39);
        int randomY = Random.Range(-317, -366);
        Image petal = (Image)Instantiate(petalObject, new Vector3(randomX, randomY, 0), Quaternion.identity);   //���� ��ǥ�� ���� ����
        petal.transform.parent = this.transform;    //�� ������Ʈ�� �ڽ� ������Ʈ�� ����

        int randomImg = Random.Range(0, 5);
        petal.sprite = petals[randomImg];

        yield return new WaitForSeconds(3f);    //1�� ��
        StartCoroutine("CreatePetals");
    }
}
