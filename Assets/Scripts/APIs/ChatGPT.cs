using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class ChatGPT
{
	private string m_OpenAI_Key; // API key
	private string m_ApiUrl = "https://api.openai.com/v1/chat/completions"; // 定义Chat API的URL
	public delegate void ProcessResponse(string msg);
	protected List<Dictionary<string, string>> m_Msgs = new List<Dictionary<string, string>>();

	[System.Serializable]public class PostData{
		public string model;
		public List<Dictionary<string, string>> messages;
		public int max_tokens; 
        public float temperature;
        public int top_p;
        public float frequency_penalty;
        public float presence_penalty;
        public string stop;
	}

	protected void addMsg(string role, string content){
		m_Msgs.Add(new Dictionary<string, string>(){
			{"role", role},
			{"content", content}
		});
	}

	protected void clearMsgs(){
		m_Msgs.Clear();
	}
 
	public IEnumerator GetPostData(ProcessResponse processResponse)
	{
		if(m_OpenAI_Key == null) m_OpenAI_Key = ResolveLocalFileAuthArgs();

		using (var request = new UnityWebRequest(m_ApiUrl, "POST"))
		{
			request.timeout = 8;

			PostData _postData = new PostData
			{
				model = "gpt-3.5-turbo",
				messages = m_Msgs,
				max_tokens = 300,
				temperature=0.8f,
				top_p=1,
			};
			string _jsonText = JsonConvert.SerializeObject(_postData);
			byte[] data = System.Text.Encoding.UTF8.GetBytes(_jsonText);
			request.uploadHandler = (UploadHandler)new UploadHandlerRaw (data);
			request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer ();
	
			request.SetRequestHeader ("Content-Type","application/json");
			request.SetRequestHeader("Authorization",string.Format("Bearer {0}",m_OpenAI_Key));
	
			yield return request.SendWebRequest();

			string _text = request.downloadHandler.text;
			if (request.responseCode == 200) {
				dynamic result = JsonConvert.DeserializeObject(_text);
				string content = (string)result.choices[0].message.content;
				addMsg("assistant", content);
				processResponse(content);
			}else{
				Debug.Log(request.downloadHandler.text);
			}
		}

	}

	private string ResolveLocalFileAuthArgs()
	{
		string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		string authPath = $"{userPath}/.openai/auth.json";
		FileInfo fi = new FileInfo(authPath);

		if (!fi.Exists) Debug.LogError("Auth file not found!");

		string json = null;
		using (FileStream fs = fi.OpenRead())
		{
			byte[] buffer = new byte[fs.Length];
			fs.Read(buffer, 0, (int)fs.Length);
			json = Encoding.UTF8.GetString(buffer);
		}
		dynamic result = JsonConvert.DeserializeObject(json);
		return result.private_api_key;
	}
}