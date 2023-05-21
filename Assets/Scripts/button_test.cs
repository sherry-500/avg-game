using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_test : MonoBehaviour
{
    public Button btn;
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClick()
    {

        //input.text = "";
        Debug.Log("click");
        btn.gameObject.SetActive(false);
        input.gameObject.SetActive(true);
        Debug.Log("input");
    }
}
