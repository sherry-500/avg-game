using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGPT : ChatGPT
{
    public IEnumerator initStory(ProcessResponse processResponse){
        addMsg("system", "你现在是一个文字游戏的主持人，主持一款文字冒险游戏，你需要针对玩家的选择推进故事发展（每次回答尽量简短并控制在150个tokens以内，不需要给出选项）。背景：身处2100年的未来世界。请展开初始剧情，向玩家描述他突然出现在2100年");
        yield return GetPostData(processResponse);
    }

    public IEnumerator GetPostStory(string _decision, ProcessResponse processResponse){
        // 检查是否初始化故事
        if(m_Msgs.Count == 0){
            Debug.Log("还没有初始化故事，请使用initStory()初始化故事");
            yield return null;
        }
        addMsg("user", "玩家决策：" + _decision);
        yield return GetPostData(processResponse);
    }

}
