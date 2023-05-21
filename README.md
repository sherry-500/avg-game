## 项目创意

结合“探索”一词，充分发挥生成式AI的优势，创造一个可自由探索的游戏世界。
在该世界中，几乎所有东西都由AI生成。

## 使用到的模型和资料

**游戏引擎**：[Unity](https://unity.com/)

**大语言模型**：[ChatGPT](https://chat.openai.com/)

**AI绘图模型**：[Stable-Diffusion](https://github.com/AUTOMATIC1111/stable-diffusion-webui)

> **checkpoint模型**：[Counterfeit-V3.0]([Counterfeit-V3.0 - v3.0 | Stable Diffusion Checkpoint | Civitai](https://civitai.com/models/4468/counterfeit-v30))

## 说明

### 配置和游玩说明（待修改）

1. 准备可以访问**ChatGPT**的`API keys`和能够访问**Stable-Diffusion**的`API url`。
2. 进入游戏，按**Home**建进入设置页面，填写`API keys`和`API url`后点击确认返回。
3. 等待一段时间游戏场景上方会出现旁白介绍游戏背景。
4. 在下方输入自己的行动决策，回车，即可等待故事的发展。

### 解题说明

**解题点一：**
每次开启游戏都会给予玩家一段关于未来世界（2100年）的开场白。
玩家可以自主输入任何想要输入的字符进行探索。

**解题点二：**
也许在不久的未来，游戏的大部分资源都可由AI生成。
游戏的开发成本大幅缩水，游戏不再受资本束缚。

我们让玩家在游戏中探索未来，而我们在制作中探索游戏的未来。

### 创新性说明

一个由AI制作的游戏。

### AI的使用说明

1. 使用[ChatGPT](https://chat.openai.com/)作为故事的推进者；
2. 在每次故事推进后，使用[ChatGPT](https://chat.openai.com/)根据描述生成[Stable-Diffusion](https://github.com/AUTOMATIC1111/stable-diffusion-webui)可识别的prompt；
3. 将prompt输入[Stable-Diffusion](https://github.com/AUTOMATIC1111/stable-diffusion-webui)生成与当前故事发展相关的图片。
