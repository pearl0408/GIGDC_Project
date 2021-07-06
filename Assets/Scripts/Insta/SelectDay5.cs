using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDay5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sprite selectPic = (Sprite)GameManager.instance.likeAlbumartList[0];
        gameObject.GetComponent<Image>().sprite = selectPic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
