using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCreditsUp : MonoBehaviour
{
    Transform startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(0, 1));
        
    }
}
