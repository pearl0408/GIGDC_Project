using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMovie : MonoBehaviour
{
    //��ȭ�� �����ϴ� �Լ�
    public movies thisMovie;

    public void SelectThisMovie()
    {
        GameManager.instance.selectMovie = thisMovie.ToString();
    }
}
