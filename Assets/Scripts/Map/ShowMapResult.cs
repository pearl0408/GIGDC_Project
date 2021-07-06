using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMapResult : MonoBehaviour
{
    public Button searchBtn; // 검색 버튼
    public InputField inputTxt; // 검색 영역
    public Text resultTxt; // 검색 텍스트
    public GameObject resultPanel;
    public Sprite noAnswer, milkyResult, homeBack; //검색결과 이미지
    public GameObject panelMap; //맵 패널

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
        if (resultTxt.text == "MILKY" || resultTxt.text == "milky" || resultTxt.text == "밀키" || resultTxt.text == "Milky")
        {
            //resultImg.SetActive(true);
            resultPanel.SetActive(true);
            panelMap.GetComponent<Image>().sprite = milkyResult;
        }
        else
        {
            panelMap.GetComponent<Image>().sprite = noAnswer;
        }
     
        yield return new WaitForSeconds(0.01f); //0.01초 딜레이
    }

    public void backHome()
    {
        panelMap.GetComponent<Image>().sprite = homeBack;
        resultPanel.SetActive(false);
    }
}
