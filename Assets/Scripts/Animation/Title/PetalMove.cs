using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalMove : MonoBehaviour
{
    //꽃잎이 날아가는 스크립트

    void Start()
    {
        StartCoroutine("MoveAndDestroyThisObject");    //오브젝트 삭제하는 코루틴 실행
    }

    
    //이동하고 자동 삭제하는 코루틴 함수
    IEnumerator MoveAndDestroyThisObject()
    {
        float timer = 0f;

        float currentX = this.GetComponent<RectTransform>().anchoredPosition.x;
        float currentY = this.GetComponent<RectTransform>().anchoredPosition.y;
        Vector2 startPosition = new Vector2(currentX, currentY);   //현재 좌표

        float randomvarX = Random.Range(400f, 700f);
        float randomvarY = Random.Range(100f, 500f);
        Vector2 targerPos = new Vector2(currentX + 720f + randomvarX, currentY + 220f + randomvarY);
        Vector2 position;

        while (timer < 10f)     //시작에 따라 위치 변경
        {
            timer += Time.deltaTime;
            position.x = Mathf.Lerp(startPosition.x, targerPos.x, timer / 10f);  //x축 이동
            position.y = Mathf.Lerp(startPosition.y, targerPos.y, timer / 10f);  //y축 이동

            this.GetComponent<RectTransform>().anchoredPosition = position;  //위치 변경
            yield return null;  
        }

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);   //자기 자신을 삭제
    }
}
