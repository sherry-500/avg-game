using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public GameObject Placeholder;

    private InputField inputField;
    private Text placeholderText;
    
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
        placeholderText = Placeholder.GetComponent<Text>();

        GameManager2.Instance.NextStoryAction += getStory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputDecision(string decision){
        GameManager2.Instance.NextDecision(decision);
        inputField.text = "";
        inputField.interactable = false;
        placeholderText.text = "请等待...";
    }

    private void getStory(string text){
        inputField.interactable = true;
        placeholderText.text = "下面请输入你的决策:";
    }
}
