using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e

public class WalkShakePhone : MonoBehaviour
{
    public GameObject phone;
<<<<<<< HEAD
    public GameObject walkNum;
    
    Vector2 moveVelocity;
    int walkNumText;
=======
    
    Vector2 moveVelocity;
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        walkNumText = 0;
        phone = GameObject.Find("Phone");
        
        walkNum = GameObject.Find("WalkNum");
        moveVelocity = new Vector2(0, 1.0f);
=======
        phone = GameObject.Find("Phone");
        
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e
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
            //�� ��ȯ
            Debug.Log("�ִϸ��̼� ��ȯ");
        }
=======
        moveVelocity = new Vector2(0, 1.0f);
>>>>>>> 5ed25e240b5916a60cfbdb31cc68ae9f2a24671e

        StartCoroutine(updown()); //���̵� �� ����
    }

    IEnumerator updown()
    {
        //����
        for (float f = 0; f <= 1; f += 0.02f)
        {
            phone.transform.Translate(moveVelocity * 400.0f * Time.deltaTime);
            this.transform.Translate(moveVelocity * 400.0f * Time.deltaTime);

            yield return new WaitForSeconds(0.001f); //0.001�� ������
        }

        //�Ʒ���
        for (float f = 0; f <= 1; f += 0.02f)
        {
            phone.transform.Translate(-1.0f*moveVelocity * 400.0f * Time.deltaTime);
            this.transform.Translate(-1.0f * moveVelocity * 400.0f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f); //0.001�� ������
        }

    }
}
