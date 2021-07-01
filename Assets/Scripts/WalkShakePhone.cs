using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WalkShakePhone : MonoBehaviour
{
    public GameObject phone;
    public GameObject walkNum;
    public GameObject success;
    
    Vector2 moveVelocity;
    int walkNumText;

    // Start is called before the first frame update
    void Start()
    {

        walkNumText = 0;
        phone = GameObject.Find("Phone_Day5");//<=���� �� �������� �̸��� �Է�
        
        walkNum = GameObject.Find("WalkNum");
        moveVelocity = new Vector2(0, 1.0f);
        success = GameObject.Find("Success");
        success.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        walkNumText += 500;
        walkNum.GetComponent<Text>().text = walkNumText.ToString();

        if(walkNumText==6000)
        {
            //�� ��ȯ
            Debug.Log("�ִϸ��̼� ��ȯ");
            success.SetActive(true);
        }

        moveVelocity = new Vector2(0, 1.0f);

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
