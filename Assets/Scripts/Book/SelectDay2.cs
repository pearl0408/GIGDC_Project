using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDay2 : MonoBehaviour
{
    public Sprite[] pics = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        string selectPic= GameManager.instance.selectBook;
        if(selectPic=="cat")
        {
            gameObject.GetComponent<Image>().sprite = pics[0];
            PlayerPrefs.SetString("SelectBook", "cat");
        }
        else if(selectPic=="bread")
        {
            gameObject.GetComponent<Image>().sprite = pics[1];
            PlayerPrefs.SetString("SelectBook", "bread");
        }
        else if(selectPic=="chicken")
        {
            gameObject.GetComponent<Image>().sprite = pics[2];
            PlayerPrefs.SetString("SelectBook", "chicken");
        }
        else if(selectPic=="dinner")
        {
            gameObject.GetComponent<Image>().sprite = pics[3];
            PlayerPrefs.SetString("SelectBook", "dinner");
        }
    }
}
