using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDay4 : MonoBehaviour
{
    public Sprite[] pics = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        string selectPic = GameManager.instance.orderFood;
        if (selectPic == "Omelet")
        {
            gameObject.GetComponent<Image>().sprite = pics[0];
        }
        else if (selectPic == "Pasta")
        {
            gameObject.GetComponent<Image>().sprite = pics[1];
        }
        else if (selectPic == "Sandwich")
        {
            gameObject.GetComponent<Image>().sprite = pics[2];
        }
        else if (selectPic == "Steak")
        {
            gameObject.GetComponent<Image>().sprite = pics[3];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
