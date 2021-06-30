using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMapResult : MonoBehaviour
{
    public Button searchBtn; // �˻� ��ư
    public InputField inputTxt; // �˻� ����
    public Text resultTxt; // �˻� �ؽ�Ʈ
    public GameObject resultImg, resultPanel;

    //private UnityEngine.TouchScreenKeyboard keyboard; // ����� Ű���� �ҷ�����
    //public static string keyboardText = ""; //�Է°� �ʱ�ȭ 

    // Start is called before the first frame update
    void Start()
    {
        searchBtn.onClick.AddListener(getResultTxt);
    }
    
    public void getResultTxt()
    {
        resultTxt.text = inputTxt.text;

        StartCoroutine(ResultFound());
       
    }

    IEnumerator ResultFound()
    {
        if (resultTxt.text == "MILKY" || resultTxt.text == "milky" || resultTxt.text == "��Ű" || resultTxt.text == "Milky")
        {
            resultImg.SetActive(true);
            resultPanel.SetActive(true);
        }
     
        yield return new WaitForSeconds(0.01f); //0.01�� ������
    }


}
