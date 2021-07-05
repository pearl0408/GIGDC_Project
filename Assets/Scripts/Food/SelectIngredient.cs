using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIngredient : MonoBehaviour
{
    //��Ḧ �����ϴ� �Լ�(��� ��ư�� �� ��ũ��Ʈ �߰�)
    public Ingredients thisIngredient;   //�ش� ���
    
    public bool isPressed;  //��ư�� ����������
    GameObject content; //��� ��ư�� �θ� ������Ʈ

    //�÷���� ����
    ColorBlock unslelctColor;
    ColorBlock selectColor;

    void Start()
    {
        content = this.gameObject.transform.parent.gameObject;
        isPressed = false;  //��ư ���� �ʱ�ȭ

        //�÷���� ����
        unslelctColor = this.GetComponent<Button>().colors;
        selectColor = this.GetComponent<Button>().colors;

        unslelctColor.normalColor = Color.white;
        //unslelctColor.highlightedColor = Color.white;
        unslelctColor.pressedColor = Color.white;
        unslelctColor.selectedColor = Color.white;

        selectColor.normalColor = Color.yellow;
        //selectColor.highlightedColor = Color.yellow;
        selectColor.pressedColor = Color.yellow;
        selectColor.selectedColor = Color.yellow;
    }

    //�ش� ��Ḧ ������ ��ư �̺�Ʈ
    public void SelectThisIngredient()
    {
        if (isPressed)  //���� ��ư�� ������ ���¶��
        {
            content.gameObject.GetComponent<OrderIngredient>().DeleteList(thisIngredient);   //������ ��� �߰�
            ResetThisSelect();
        }
        else    //���� ��ư�� ������ ���°� �ƴ϶��
        {
            content.gameObject.GetComponent<OrderIngredient>().AddList(thisIngredient);    //������ ��� ����
            SelectThis();
        }
    }

    public void ResetThisSelect()
    {
        this.GetComponent<Button>().colors = unslelctColor;   //��ư ���� �ٲٱ�
        isPressed = false;  //��ư ���� ���� ����
    }

    public void SelectThis()
    {
        this.GetComponent<Button>().colors = selectColor;   //��ư ���� �ٲٱ�
        isPressed = true;   //��ư ���� ����
    }
}
