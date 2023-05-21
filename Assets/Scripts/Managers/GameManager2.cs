using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance {get; private set;}

    public Action<string> NextStoryAction;

    private StoryGPT m_StoryGPT = new StoryGPT();

    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame(){
        StartCoroutine(m_StoryGPT.initStory(NextStory));
    }

    // 输入玩家决策
    public void NextDecision(string decision){
        StartCoroutine(m_StoryGPT.GetPostStory(decision, NextStory));
    }

    // 推进故事
    void NextStory(string story){
        NextStoryAction?.Invoke(story);
        Debug.Log(story);
    }

    public void EndGame(){

    }
}
