using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMapResult : MonoBehaviour
{
    public Button searchBtn; // �˻� ��ư
    public InputField inputTxt; // �˻� ����
    public Text resultTxt; // �˻� �ؽ�Ʈ
    public GameObject resultPanel;
    public Sprite noAnswer, milkyResult, homeBack; //�˻���� �̹���
    public GameObject panelMap; //�� �г�

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
            //resultImg.SetActive(true);
            resultPanel.SetActive(true);
            panelMap.GetComponent<Image>().sprite = milkyResult;
        }
        else
        {
            panelMap.GetComponent<Image>().sprite = noAnswer;
        }
     
        yield return new WaitForSeconds(0.01f); //0.01�� ������
    }

    public void backHome()
    {
        panelMap.GetComponent<Image>().sprite = homeBack;
        resultPanel.SetActive(false);
    }
}
