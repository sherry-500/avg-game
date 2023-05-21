using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    private List<ScriptData> scriptDatas;
    private int scriptIndex;
    private ChatGPTController chatController;
    private void Awake() {
        Instance = this;
        scriptDatas = new List<ScriptData>() {    
              new ScriptData() {
            },          
            new ScriptData() {
                loadType=1, spriteName="Title"
            },
            new ScriptData() {
                loadType=2, name="Test", dialogueContent="你好，我叫Test"
            },
            new ScriptData() {
                loadType=2, name="Test", dialogueContent="你真厉害，这么快就学会了"
            }
        };
        scriptIndex = 0;
        HandleData();
    }

 //   public void Start() {
 //       chatController = GameObject.Find("ChatManager").GetComponent<ChatGPTController>();
 //       string userMessage = "Hello, how are you?";
 //       chatController.SendUserMessage(userMessage);        
 //   }

    private void Update() {

    }

    private void HandleData (){
        if (scriptIndex >= scriptDatas.Count) {
            Debug.Log("游戏结束");
            return;
        }
        if (scriptDatas[scriptIndex].loadType==1) {
            //背景
            //设置一下背景图片
            SetBGImageSprite(scriptDatas[scriptIndex].spriteName);
            //加载下一条剧情数据
            LoadNextScript();
        } else if (scriptDatas[scriptIndex].loadType==2) {
            //人物
            //显示人物
            ShowCharacter(scriptDatas[scriptIndex].name);
            //更新对话框文本
            UpdateTalkLineText(scriptDatas[scriptIndex].dialogueContent);
        }
    }

    private void SetBGImageSprite(string spriteName) {
        UIManager.Instance.SetBGImageSprite(spriteName);
    }

    public void LoadNextScript() {
        Debug.Log("next");
        scriptIndex++;
        HandleData();
    }

    private void ShowCharacter(string name) {
        UIManager.Instance.ShowCharacter(name);
    }

    private void UpdateTalkLineText(string dialogueContent) {
        UIManager.Instance.UpdateTalkLineText(dialogueContent);
    }
}

public class ScriptData {
    public int loadType; //载入资源类型 1背景 2人物
    public string name; // 角色名称
    public string spriteName; // 图片资源路径
    public string dialogueContent; // 对话内容
}