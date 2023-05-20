using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChatGPT
{
	private string m_OpenAI_Key="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"; // API key
	private string m_ApiUrl = "https://api.openai.com/v1/completions"; // 定义Chat API的URL
    [SerializeField]private PostData m_PostDataSetting; // 配置参数
 
	[System.Serializable]public class PostData{
		public string model;
		public string prompt;
		public int max_tokens; 
        public float temperature;
        public int top_p;
        public float frequency_penalty;
        public float presence_penalty;
        public string stop;
	}
 
	public IEnumerator GetPostData(string _postWord, System.Action<string> _callback)
	{
        Debug.Log("GetPostData");
		var request = new UnityWebRequest (m_ApiUrl, "POST");
		PostData _postData = new PostData
		{
			model = m_PostDataSetting.model,
			prompt = _postWord,
			max_tokens = m_PostDataSetting.max_tokens,
            temperature=m_PostDataSetting.temperature,
            top_p=m_PostDataSetting.top_p,
            frequency_penalty=m_PostDataSetting.frequency_penalty,
            presence_penalty=m_PostDataSetting.presence_penalty,
            stop=m_PostDataSetting.stop
		};
 
		string _jsonText = JsonUtility.ToJson (_postData);
		byte[] data = System.Text.Encoding.UTF8.GetBytes (_jsonText);
		request.uploadHandler = (UploadHandler)new UploadHandlerRaw (data);
		request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer ();
 
		request.SetRequestHeader ("Content-Type","application/json");
		request.SetRequestHeader("Authorization",string.Format("Bearer {0}",m_OpenAI_Key));
 
		yield return request.SendWebRequest ();
 
		if (request.responseCode == 200) {
			string _msg = request.downloadHandler.text;
			TextCallback _textback = JsonUtility.FromJson<TextCallback> (_msg);
			if (_textback!=null && _textback.choices.Count > 0) {
                _callback(_textback.choices [0].text);
			}
		}

            //         // OpenAI API地址
            // string apiUrl = "https://api.openai.com/v1/engines/gpt-3/jobs";

            // // OpenAI API密钥
            // string apiKey = "YOUR_API_KEY";

            // // 创建一个RestClient对象
            // var client = new RestClient(apiUrl);

            // // 创建一个RestRequest对象
            // var request = new RestRequest(Method.POST);

            // // 在请求头中添加API密钥
            // request.AddHeader("Authorization", "Bearer " + apiKey);

            // // 添加请求内容
            // request.AddJsonBody(new
            // {
            //     model = "text-davinci-002",
            //     prompt = "What is the capital of France?",
            //     max_tokens = 100,
            //     n = 1,
            //     stop = null,
            //     temperature = 0.5,
            // });

            // // 发送请求并获取响应
            // IRestResponse response = client.Execute(request);

            // // 显示响应内容
            // Console.WriteLine(response.Content);
            // Console.ReadLine();
	}
 
	/// <summary>
	/// 返回的信息
	/// </summary>
	[System.Serializable]public class TextCallback{
		public string id;
		public string created;
		public string model;
		public List<TextSample> choices;
 
		[System.Serializable]public class TextSample{
			public string text;
			public string index;
			public string finish_reason;
		}
 
	}
}
