using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Ingredients { egg, ketchup, rice, noodle, shrimp, tomato, bread, bacon, cheese, herb, meat, pepper};    //��� ������ ���� ����

public class OrderIngredient : MonoBehaviour
{
    //��Ḧ �����ϰ� �ֹ��ϴ� �Լ�
    static List<Ingredients> selectIngredients = new List<Ingredients>();  //������ ��� ����Ʈ
    int numberOfSelect; //������ ����


    void Start()
    {
        numberOfSelect = 0;
    }

    //�� ���� ��Ḧ �����ߴٸ� �ֹ��ϴ� �Լ�(�ֹ��ϱ� ��ư �̺�Ʈ)
    public void OrderThreeIngredient()
    {
        if (numberOfSelect == 3)    //������ ��ᰡ 3�����
        {
            if (selectIngredients.Contains(Ingredients.egg) && selectIngredients.Contains(Ingredients.ketchup) && selectIngredients.Contains(Ingredients.rice))    //���Ƕ��̽� ��ᰡ �� ���õƴٸ�
            {
                GameManager.instance.orderFood = "Omelet"; 
            }
            else if (selectIngredients.Contains(Ingredients.noodle) && selectIngredients.Contains(Ingredients.shrimp) && selectIngredients.Contains(Ingredients.tomato))  //�Ľ�Ÿ ��ᰡ �� ���õƴٸ�
            {
                GameManager.instance.orderFood = "Pasta";
            }
            else if (selectIngredients.Contains(Ingredients.bread) && selectIngredients.Contains(Ingredients.bacon) && selectIngredients.Contains(Ingredients.cheese))  //������ġ ��ᰡ �� ���õƴٸ�
            {
                GameManager.instance.orderFood = "Sandwich";
            }
            else if (selectIngredients.Contains(Ingredients.herb) && selectIngredients.Contains(Ingredients.meat) && selectIngredients.Contains(Ingredients.pepper))  //������ũ ��ᰡ �� ���õƴٸ�
            {
                GameManager.instance.orderFood = "Steak";
            }
            else    //��� ������ Ʋ�ȴٸ� ���� �ʱ�ȭ
            {
                GameManager.instance.orderFood = "";
                ResetSelect();
            }
        }
        else    //�ƴ϶�� ���� �ʱ�ȭ
        {
            GameManager.instance.orderFood = "";
            ResetSelect();
        }
    }

    //���õ� ��Ḧ ���� ���� �ϴ� �Լ�(�ֹ��ϱ� ��ư ���н�)
    public void ResetSelect()
    {
        selectIngredients.Clear();    //����Ʈ �����
        numberOfSelect = 0;

        for (int i = 0; i < 12; i++)
        {
            //��ư ���� �ٲٱ�
            this.transform.GetChild(i).gameObject.GetComponent<SelectIngredient>().ResetThisSelect();    //��ư ���� ���� ����
        }
    }

    //��Ḧ �߰��ϴ� �Լ�
    public void AddList(Ingredients content)
    {
        selectIngredients.Add(content); //��� �߰�
        numberOfSelect++;
    }

    //��Ḧ �����ϴ� �Լ�
    public void DeleteList(Ingredients content)
    {
        selectIngredients.Remove(content);  //��� ����
        numberOfSelect--;
    }
}
