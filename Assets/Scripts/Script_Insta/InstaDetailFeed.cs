using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstaDetailFeed : MonoBehaviour
{
    public ScrollRect sr;

    void Awake()
    {
        sr = gameObject.GetComponent<ScrollRect>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goMyfeed(int i)
    {
        sr.content.localPosition = new Vector3(0, i*1300, 0);
    }
}
