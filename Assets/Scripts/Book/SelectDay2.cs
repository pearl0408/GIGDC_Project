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
        }
        else if(selectPic=="bread")
        {
            gameObject.GetComponent<Image>().sprite = pics[1];
        }
        else if(selectPic=="chicken")
        {
            gameObject.GetComponent<Image>().sprite = pics[2];
        }
        else if(selectPic=="dinner")
        {
            gameObject.GetComponent<Image>().sprite = pics[3];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
