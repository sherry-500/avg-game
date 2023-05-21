using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenAi.Unity.V1;
using System.Drawing;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System;

public class input_test : MonoBehaviour
{
    public InputField m_InputField;
    public Text output;
    public UnityEngine.UI.Image img;
    

    private void Awake()
    {
        output.text = "你是一位正在森林中冒险的旅人,行进中发现前方似乎被浓雾遮盖,下面请做出你的选择";
    }
    // Start is called before the first frame update
    void Start()
    {
        ChatWithGPT("你是文字冒险游戏的主持人，我的身份是一位正在森林中冒险的旅人,现在我在行进中发现前方似乎被浓雾遮盖,下面我会做出选择，请根据我的选择主持这场游戏，我先说");
        m_InputField.gameObject.SetActive(true);
        output.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void ChatWithGPT(string text) {
        OpenAiChatCompleterV1.Instance.Complete(
              text,
              s => {  },
              e => output.text = $"ERROR: StatusCode: {e.responseCode} - {e.error}"
);
    }

    public void OnEnd()
    {
        output.text = "";
        Debug.Log("onend");
       string text = m_InputField.text;
        if (string.IsNullOrEmpty(text))
        {
            Debug.LogError("Example requires input in Input field");
            return;
        }
        if(output == null)
        {
            Debug.Log("text is null");
            return;
        }
        
        Debug.Log(output.text);
        getPicture(text);

        img.sprite = Resources.Load("output", typeof(Sprite)) as Sprite;
        OpenAiChatCompleterV1.Instance.Complete(
     text,
     s => { output.text = s.Replace("\n", "").Replace(" ", ""); },
     e => output.text = $"ERROR: StatusCode: {e.responseCode} - {e.error}"
     );
        output.text.Replace("\n", "").Replace(" ", "").Replace("\\n","");
        m_InputField.text = "";
    }

    public void getPicture(string tokens)
    {
        string url = "https://u6370-b1ae-f97271ae.neimeng.seetacloud.com:6443";
        var payload = new
        {
           
            prompt = tokens,
            steps = 50

        };

      
        
        using (WebClient client = new WebClient())
        {
            //client.Headers[HttpRequestHeader.Authorization] = "Bearer eyJhbGciOiJFUzUxMiIsInR5cCI6IkpXVCJ9.eyJhZGRyIjoiMTc2Ljk3LjIxMC4yNDYiLCJlbWFpbCI6InRlYW03QGhhY2subGNwdS5uZXQiLCJleHAiOjE3MTYxMjIxNjMsImlhdCI6MTY4NDU4NjE2MywiaXNzIjoiaHR0cHM6Ly9oYWNrdXNlci5sY3B1Lm5ldC9sb2dpbiIsImp0aSI6InA4YzRxbTdCV3pCWDVpZWJ4ZlFja1VHWTZSN2RUSEZJSG5McTVvbm5kIiwibmJmIjoxNjg0NTg2MTAzLCJvcmlnaW4iOiJsb2NhbCIsInJvbGVzIjpbImF1dGhwL3VzZXIiXSwic3ViIjoidGVhbTcifQ.AOdolzBYqMaIo0ImzR_sfEAdxTlghbZPpx7zWj3KWkJl_Z4ItHvuOkSvsmJ1j_mYS5_hdxZffDRSGX1r_4c1YvIKAHMRHSMdh7sTbtYs_9T5AJ_AlHlI74dq79knAh6N2E4411DAFExpItOq8mJqPH2yfmAdG0SW7aAT6j0xkb0Dx3K-";
            string jsonPayload = JsonConvert.SerializeObject(payload);
           

            string response = client.UploadString($"{url}/sdapi/v1/txt2img", jsonPayload);

               
            dynamic r = JsonConvert.DeserializeObject(response);

            Debug.Log(1);
            byte[] imageBytes = Convert.FromBase64String(r.images[0].ToString().Split(",", 2)[0]);
           
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
           
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                
                image.Save("Assets/Resources/output.png");
            };

            Debug.Log("success");

        }
    }
}
