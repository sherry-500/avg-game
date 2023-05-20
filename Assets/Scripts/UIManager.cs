using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}
    public Image imgBG;
    public Image imgCharacter;
    public Text textName;
    public Text textTalkLine;
    public GameObject talkLineGo; //对话框父对象

    private void Awake () {
        Instance = this;
    }

    public void SetBGImageSprite(string spriteName) {
        imgBG.sprite = Resources.Load<Sprite>("Sprites/BG/" + spriteName);
        imgBG.gameObject.SetActive(true);
    }

    public void ShowCharacter(string name) {
        talkLineGo.gameObject.SetActive(true);
        imgCharacter.sprite = Resources.Load<Sprite>("Sprites/Characters/" + name);
        imgCharacter.gameObject.SetActive(true);
        textName.text = name;
    }

    public void UpdateTalkLineText(string dialogueContent) {
        textTalkLine.text = dialogueContent;
    }
}
