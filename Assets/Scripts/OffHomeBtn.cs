using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffHomeBtn : MonoBehaviour
{
    public GameObject onPanel;
    //public string onPanelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setName(string name)
    {
        //onPanelName = name;
        onPanel = GameObject.Find("Panel_" + name);
        Debug.Log(name);
    }

    public void backHome()
    {
        onPanel.SetActive(false);
    }
}
