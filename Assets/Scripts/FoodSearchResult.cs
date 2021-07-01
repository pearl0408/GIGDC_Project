using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class FoodSearchResult : MonoBehaviour
{
    //���� �˻� ����� �����ִ� ��ũ��Ʈ

    public Text searchKeyword;  //�˻��� �ؽ�Ʈ
    public Text foodNameText;   //���� �̸� �ؽ�Ʈ

    public GameObject[] ingredientList; //��� �迭

    public Sprite[] ingredientSprite_Omelet;   // ���ɷ� ��� �̹��� �迭
    public Sprite[] ingredientSprite_Pasta;   // �Ľ�Ÿ ��� �̹��� �迭
    public Sprite[] ingredientSprite_Sandwich;   // ������ġ ��� �̹��� �迭
    public Sprite[] ingredientSprite_Steak;   // ������ũ ��� �̹��� �迭

    private string[] Omelet_ingredient_Text = { "�ް�", "��ø", "��",
        "���� ���� ��", "�丶�並 ���� ����� ����� ���̷�", "�� ������ ������ ���� �˰���"};  //���ɷ� ��� ���� ���ڿ� �迭

    private string[] Pasta_ingredient_Text = { "��", "����", "�丶��",
        "�а��� ���� ������ ���ð� ��� �̾Ƴ� ��ǰ", "�ʰ��� ��̾Ƹ� ���ϴ� ���������� ��Ī", "�ֶ��ٽĹ� ��ȭ�Ĺ��� �������� ���ػ���Ǯ"};  //�Ľ�Ÿ ���� ���ڿ� �迭

    private string[] Sandwich_ingredient_Text = { "�Ļ�", "������", "ġ��",
        "Ʋ�� �־� ���� �� ��", "������⸦ �ұݿ� ���� �ƿ��� ��ǰ", "�����ܹ����� �����Ų ��ǰ" };  //������ġ ���� ���ڿ� �迭

    private string[] Steak_ingredient_Text = { "���", "���", "����",
        "ǳ�̰� �ְų� ���� ���� �Ĺ�", "�������� ���� �� �ִ� ��", "���߳����� ����" };  //������ũ ���� ���ڿ� �迭

    //������Ʈ�� Ȱ��ȭ �� ������
    private void OnEnable()
    {
        string searchFood = GameManager.instance.searchFood;    //�˻��� ������ ������
        searchKeyword.text = searchFood + " ������";   //���� �˻� �ؽ�Ʈ ����

        //�˻��� ���Ŀ� ���� �̹���, �ؽ�Ʈ ����
        if (searchFood == "���ɷ�")
        {
            foodNameText.text = "���ɷ�";  //�丮 �̸� ����
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "�������� ��ǥ���� �ް� �丮";    //�丮 ���� ����

            //��� �̹���, �ؽ�Ʈ ����
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Omelet[i];  //��� �̹��� ����

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //��� �ؽ�Ʈ ������Ʈ�� ������
                ingredient_Text.GetComponent<Text>().text = Omelet_ingredient_Text[i];  //��� �̸� ����
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Omelet_ingredient_Text[i + 3];  //��� ���� ����
            }

        }
        else if (searchFood == "�Ľ�Ÿ")
        {
            foodNameText.text = "�Ľ�Ÿ";  //�丮 �̸� ����
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "���� �а��縦 ����Ͽ� ����� ��Ż���� �����丮";    //�丮 ���� ����

            //��� �̹���, �ؽ�Ʈ ����
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Pasta[i];  //��� �̹��� ����

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //��� �ؽ�Ʈ ������Ʈ�� ������
                ingredient_Text.GetComponent<Text>().text = Pasta_ingredient_Text[i];  //��� �̸� ����
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Pasta_ingredient_Text[i + 3];  //��� ���� ����
            }
        }
        else if (searchFood == "������ġ")
        {
            foodNameText.text = "������ġ";  //�丮 �̸� ����
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "�� ���̿� �ҽ��� �ٸ��� ��Ḧ ���� ���� ����";    //�丮 ���� ����

            //��� �̹���, �ؽ�Ʈ ����
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Sandwich[i];  //��� �̹��� ����

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //��� �ؽ�Ʈ ������Ʈ�� ������
                ingredient_Text.GetComponent<Text>().text = Sandwich_ingredient_Text[i];  //��� �̸� ����
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Sandwich_ingredient_Text[i + 3];  //��� ���� ����
            }
        }
        else    //searchFood == "������ũ"
        {
            foodNameText.text = "������ũ";  //�丮 �̸� ����
            foodNameText.gameObject.transform.GetChild(0).GetComponent<Text>().text = "�β��� ���� ������ ���� ����丮";    //�丮 ���� ����

            //��� �̹���, �ؽ�Ʈ ����
            for (int i = 0; i < 3; i++)
            {
                ingredientList[i].transform.GetChild(0).GetComponent<Image>().sprite = ingredientSprite_Steak[i];  //��� �̹��� ����

                GameObject ingredient_Text = ingredientList[i].transform.GetChild(1).gameObject;    //��� �ؽ�Ʈ ������Ʈ�� ������
                ingredient_Text.GetComponent<Text>().text = Steak_ingredient_Text[i];  //��� �̸� ����
                ingredient_Text.transform.GetChild(0).GetComponent<Text>().text = Steak_ingredient_Text[i + 3];  //��� ���� ����
            }
        }
    }



}
