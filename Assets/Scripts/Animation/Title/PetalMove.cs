using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalMove : MonoBehaviour
{
    //������ ���ư��� ��ũ��Ʈ

    void Start()
    {
        StartCoroutine("MoveAndDestroyThisObject");    //������Ʈ �����ϴ� �ڷ�ƾ ����
    }

    
    //�̵��ϰ� �ڵ� �����ϴ� �ڷ�ƾ �Լ�
    IEnumerator MoveAndDestroyThisObject()
    {
        float timer = 0f;

        float currentX = this.GetComponent<RectTransform>().anchoredPosition.x;
        float currentY = this.GetComponent<RectTransform>().anchoredPosition.y;
        Vector2 startPosition = new Vector2(currentX, currentY);   //���� ��ǥ

        float randomvarX = Random.Range(400f, 700f);
        float randomvarY = Random.Range(100f, 500f);
        Vector2 targerPos = new Vector2(currentX + 720f + randomvarX, currentY + 220f + randomvarY);
        Vector2 position;

        while (timer < 10f)     //���ۿ� ���� ��ġ ����
        {
            timer += Time.deltaTime;
            position.x = Mathf.Lerp(startPosition.x, targerPos.x, timer / 10f);  //x�� �̵�
            position.y = Mathf.Lerp(startPosition.y, targerPos.y, timer / 10f);  //y�� �̵�

            this.GetComponent<RectTransform>().anchoredPosition = position;  //��ġ ����
            yield return null;  
        }

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);   //�ڱ� �ڽ��� ����
    }
}
