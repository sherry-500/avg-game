using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ChatGPTController : MonoBehaviour
{
    private const string PythonServerURL = "http://localhost:5000"; // 替换为你的Python服务器地址

    public void SendUserMessage(string message)
    {
        StartCoroutine(PostRequest(message));
    }

    private IEnumerator PostRequest(string message)
    {
        string url = PythonServerURL + "/chat"; // 替换为你的Python服务器上处理请求的路由
        string json = "{\"message\": \"" + message + "\"}";
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error sending request: " + request.error);
            }
            else
            {
                string responseJson = request.downloadHandler.text;
                // 处理接收到的响应
                ProcessResponse(responseJson);
            }
        }
    }

    private void ProcessResponse(string responseJson)
    {
        // 在这里处理接收到的响应
        // 例如，你可以将响应转换为Unity中的文本显示或执行相关操作
        Debug.Log("Received response: " + responseJson);
    }
}
