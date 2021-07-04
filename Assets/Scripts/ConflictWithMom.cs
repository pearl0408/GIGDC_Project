using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConflictWithMom : MonoBehaviour
{
    public Button leftBtn, rightBtn; // select버튼

    // 타이핑 변수
    public Text mom_TypingText_1; // 타이핑 메세지
    public string mom_Message; // 전송 메세지

    public Text my_TypingText_1; // 타이핑 메세지
    public string my_Message; // 전송 메세지

    public float typing_Speed = 0.2f; // 타이핑 속도

    // 선택 메세지
    public Text targetTxt;

    public Button targetPanel;
    public int selectPage; // 화면이 가리키는 위치 

  

  

    //언제까지 놀기만 할꺼니 (타이핑 효과)/부모님쪽으로 기울어짐
    // 선택 대기 
    // 버튼 눌러서 
    // 해당 패널이 선택되면 
    // 타이핑 효과로 넣어주기(내쪽으로 화면 기울어짐)

    // Start is called before the first frame update
    void Start()
    {
        selectPage = 1;
        mom_Message ="mom1";
        my_Message = "my1";
        StartCoroutine(momTyping(mom_TypingText_1, mom_Message, typing_Speed));

    }

    // 엄마의 메세지가 타이핑되고 기울어짐(왼쪽)
    IEnumerator momTyping(Text typingText, string message, float speed)
    {
        yield return new WaitForSeconds(5f);

        // 메세지 타이핑
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }

        if(message == "mom1")
        {
            GameObject.Find("Phone_complete Variant").transform.Rotate(0, 0, 30);

        }else if(message == "mom2")
        {
            GameObject.Find("Phone_complete Variant").transform.Rotate(0, 0, 60);
        }
        else if(message == "mom3")
        {
            GameObject.Find("Phone_complete Variant").transform.Rotate(0, 0, 60);
        }
      

        //선택대기
        StartCoroutine(selectMsg());
   
    }

    // 나의 메세지가 타이핑되고 기울어짐(오른쪽)
    IEnumerator myTyping(Text typingText, string message, float speed)
    {
        if (message == "my1")
        {
            // 메세지 타이핑
            for (int i = 0; i < message.Length; i++)
            {
                typingText.text = message.Substring(0, i + 1);
                yield return new WaitForSeconds(speed);
            }

            mom_TypingText_1.text = "mom2";


            // 화면 기울어짐(오른쪽)
            GameObject.Find("Phone_complete Variant").transform.Rotate(0, 0, -60);

            StartCoroutine(momTyping(mom_TypingText_1, "mom2", speed));
        }

        if (message == "my2")
        {
            // 메세지 타이핑
            for (int i = 0; i < message.Length; i++)
            {
                typingText.text = message.Substring(0, i + 1);
                yield return new WaitForSeconds(speed);
            }


            mom_TypingText_1.text = "mom3";


            // 화면 기울어짐(오른쪽)
            GameObject.Find("Phone_complete Variant").transform.Rotate(0, 0, -60);

            StartCoroutine(momTyping(mom_TypingText_1, "mom3", speed));
        }

     

      
        //GameObject.Find("Phone_complete Variant").transform.Rotate(0, 0, 30);
        //yield return new WaitForSeconds(0.2f);

        if (message == "my3")
        {
            GameObject.Find("Phone_complete Variant").transform.Rotate(0, 0, -30);
            yield return new WaitForSeconds(0.2f);
        }
    }

    // 딸 대사 선택 하기
    IEnumerator selectMsg()
    {
        // 왼쪽 버튼 클릭 
        leftBtn.onClick.AddListener(leftBtnClicked);

        // 오른쪽 버튼 클릭
        rightBtn.onClick.AddListener(rightBtnClicked);

        yield return new WaitForSeconds(1.0f);

    }
    

    public void leftBtnClicked()
    {

        if (selectPage == 1)
        {
            selectPage = 1;
            targetTxt.text = "my1";
            targetPanel.onClick.AddListener(matchCheckNo1);
        
        }
        else
        {
            selectPage--;

            if(selectPage == 2)
            {
                targetTxt.text = "my2";
                targetPanel.onClick.AddListener(matchCheckNo2);
                

            }else if(selectPage == 3)
            {
                targetTxt.text = "my3";
                targetPanel.onClick.AddListener(matchCheckNo3);
         
            }

 

        }


    }

    public void rightBtnClicked()
    {

       if(selectPage > 3)
        {
            selectPage = 3;
            targetTxt.text = "my3";

            targetPanel.onClick.AddListener(matchCheckNo3);

        }
        else
        {
            selectPage++;

            if (selectPage == 2)
            {
                targetTxt.text = "my2";
           
                targetPanel.onClick.AddListener(matchCheckNo2);

            }else if(selectPage == 3)
            {
                targetTxt.text = "my3";
              
                targetPanel.onClick.AddListener(matchCheckNo3);

            }else if(selectPage == 1)
            {
                targetTxt.text = "my1";
         
                targetPanel.onClick.AddListener(matchCheckNo1);

            }
        }



    }

    // match_1
    public void matchCheckNo1()
    {
   
        if(targetTxt.text == "my1" && mom_TypingText_1.text == "mom1")
        {
            StartCoroutine(myTyping(my_TypingText_1, "my1", typing_Speed));
        }

    }


    // match_2
    public void matchCheckNo2()
    {
        if (targetTxt.text == "my2" && mom_TypingText_1.text == "mom2")
        {
            my_TypingText_1.text = "my2";
            my_Message = "my2";
            StartCoroutine(myTyping(my_TypingText_1, "my2", typing_Speed));
        }

    }

    //match_3
    public void matchCheckNo3()
    {
        if (targetTxt.text == "my3" && mom_TypingText_1.text == "mom3")
        {
            my_TypingText_1.text = "my3";
            my_Message = "my3";
            StartCoroutine(myTyping(my_TypingText_1, "my3", typing_Speed));
        }

    }

}
