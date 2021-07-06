using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkScrollSet : MonoBehaviour
{
    
    public ScrollRect sr;

    // Start is called before the first frame update

    void Awake()
    {
        sr = gameObject.GetComponent<ScrollRect>();
        sr.content.localPosition = new Vector3(0, 1000, 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
