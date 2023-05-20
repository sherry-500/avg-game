using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UIController");
        ChatGPT chatGPT = new ChatGPT();
        chatGPT.GetPostData("你好", (string _text) =>
        {
            Debug.Log(_text);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
