using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuffleIngredient : MonoBehaviour
{
    //��Ʈ ���ÿ��� ��� ����� �������� ���� �Լ�

    public Button[] IngredientList;   //��� ��ư ���

    void Start()
    {
        Shuffle(IngredientList);  //�迭 ����

        //��� ��ư ����
        for (int i = 0; i < IngredientList.Length; i++)
        {
            //��ư ����
            Button Btn_Ingredient = (Button)Instantiate(IngredientList[i]);   //��ư ����
            Btn_Ingredient.gameObject.transform.SetParent(this.gameObject.transform); //���� ������Ʈ�� �ڽ� ������Ʈ�� ����
        }
    }

    //���� �Լ�
    void Shuffle(Button[] btnArray)
    {
        int random1, random2;   //�ε���
        Button tempBtn; //�ӽ� ��ư

        for (int i = 0; i < btnArray.Length; i++)
        {
            random1 = Random.Range(0, btnArray.Length);    //���� �ε��� ����
            random2 = Random.Range(0, btnArray.Length);    //���� �ε��� ����

            tempBtn = btnArray[random1];    //�ӽ� ��ư ����
            btnArray[random1] = btnArray[random2];  //��ư ����
            btnArray[random2] = tempBtn;    //�ӽ� ��ư ����
        }
    }
}
