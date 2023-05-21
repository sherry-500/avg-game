using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromteGPT : ChatGPT
{
    private List<Dictionary<string, string>> m_Msgs = new List<Dictionary<string, string>>();

    public IEnumerator GetPromte(string _describe, ProcessResponse processResponse){
        m_Msgs = new List<Dictionary<string, string>>();
        m_Msgs.Add(new Dictionary<string, string>(){
			{"role", "assistant"},
			{"content", "Stable Diffusion是一款利用深度学习的文生图模型，支持通过使用提示词来产生新的图像，描述要包含或省略的元素。我在这里引入Stable Diffusion算法中的Prompt概念，又被称为提示符。这里的Prompt通常可以用来描述图像，他由普通常见的单词构成，最好是可以在数据集来源站点找到的著名标签（比如Ddanbooru）。下面我将说明Prompt的生出步骤，这里的Prompt主要用于描述人物。在Prompt的生成中，你需要通过提示词来描述 人物属性，主题，外表，情绪，衣服，姿势，视角，动作，背景。用英语单词或短语甚至自然语言的标签来描述，并不局限于我给你的单词。然后将你想要的相似的提示词组合在一起，请使用英文半角,做分隔符，每个提示词不要带引号，并将这些 按从最重要到最不重要的顺序排列。人物属性中，1girl表示你生成了一个女孩，2girls表示生成了两个女孩。另外再注意，Prompt中不能带有-和_。可以有空格和自然语言，但不要太多，单词不能重复。例如: (((best quality))),(((ultra detailed))),(((masterpiece))),illustration,boy,adventure,dangerous,dragon,fantasy,village,armor,weapon,forest,path"}
		});
        m_Msgs.Add(new Dictionary<string, string>(){
			{"role", "user"},
			{"content", "write a prompt about:" + _describe}
		});
        yield return GetPostData(m_Msgs, processResponse);
    }

    internal string GetPromte(string v)
    {
        throw new NotImplementedException();
    }
}
