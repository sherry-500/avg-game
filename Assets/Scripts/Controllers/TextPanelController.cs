using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanelController : MonoBehaviour
{
    public GameObject textContent;
    private Text storyText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager2.Instance.NextStoryAction += getStory;

        storyText = textContent.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getStory(string text){
        storyText.text = storyText.text + '\n' + text;
    }
}
