using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockMove : MonoBehaviour
{
    //�ð� �ٴ��� ������ ȭ���� ��ο����� ������� �ϴ� ��ũ��Ʈ

    public Image LightImg;  //������ ������ �̹���

    void Update()
    {
        if (Input.touchCount > 0)  //ȭ���� ��ġ�ϸ�
        {
            Vector2 mPosition = Input.mousePosition;    //��ġ ��ǥ ����
            Ray ray = Camera.main.ScreenPointToRay(mPosition);
        }
    }

    //�ð�ٴ� ȸ�� �ڵ� �ۼ� �ʿ�
}
