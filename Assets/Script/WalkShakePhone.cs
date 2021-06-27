using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e
=======
using UnityEngine.UI;
>>>>>>> 2ed0fb9fa31d0ae4c3a6228664d9d94698fe0b58

public class WalkShakePhone : MonoBehaviour
{
    public GameObject phone;
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 2ed0fb9fa31d0ae4c3a6228664d9d94698fe0b58
    public GameObject walkNum;
    
    Vector2 moveVelocity;
    int walkNumText;
<<<<<<< HEAD
=======
    
    Vector2 moveVelocity;
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e
=======
>>>>>>> 2ed0fb9fa31d0ae4c3a6228664d9d94698fe0b58

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 2ed0fb9fa31d0ae4c3a6228664d9d94698fe0b58
        walkNumText = 0;
        phone = GameObject.Find("Phone");
        
        walkNum = GameObject.Find("WalkNum");
        moveVelocity = new Vector2(0, 1.0f);
<<<<<<< HEAD
=======
        phone = GameObject.Find("Phone");
        
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e
=======
>>>>>>> 2ed0fb9fa31d0ae4c3a6228664d9d94698fe0b58
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
<<<<<<< HEAD
        walkNumText += 500;
        walkNum.GetComponent<Text>().text = walkNumText.ToString();

        if(walkNumText==6000)
        {
            //씬 전환
            Debug.Log("애니메이션 전환");
        }
=======
        moveVelocity = new Vector2(0, 1.0f);
<<<<<<< HEAD
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e
=======
>>>>>>> origin/main
>>>>>>> 2ed0fb9fa31d0ae4c3a6228664d9d94698fe0b58

        StartCoroutine(updown()); //페이드 인 시작
    }

    IEnumerator updown()
    {
        //위로
        for (float f = 0; f <= 1; f += 0.02f)
        {
            phone.transform.Translate(moveVelocity * 400.0f * Time.deltaTime);
            this.transform.Translate(moveVelocity * 400.0f * Time.deltaTime);

            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

        //아래로
        for (float f = 0; f <= 1; f += 0.02f)
        {
            phone.transform.Translate(-1.0f*moveVelocity * 400.0f * Time.deltaTime);
            this.transform.Translate(-1.0f * moveVelocity * 400.0f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f); //0.001초 딜레이
        }

    }
}
