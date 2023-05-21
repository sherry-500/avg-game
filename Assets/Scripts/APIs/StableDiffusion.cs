using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableDiffusion
{
    // public TMP_InputField m_InputField;
    // public Text output;
    // public UnityEngine.UI.Image img;

    // private void Awake()
    // {
        
    // }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // public void OnEnd()
    // {
    //    string text = m_InputField.text;
    //     if (string.IsNullOrEmpty(text))
    //     {
    //         Debug.LogError("Example requires input in Input field");
    //         return;
    //     }
    //     if(output == null)
    //     {
    //         Debug.Log("text is null");
    //         return;
    //     }
    //     OpenAiCompleterV1.Instance.Complete(
    //         text,
    //         s => { output.text = s; },
    //         e => output.text = $"ERROR: StatusCode: {e.responseCode} - {e.error}"
    //         );
    //     //getPicture("a cute cat");
    //     //Sprite sprite = Resources.Load("output", typeof(Sprite)) as Sprite;
    //     //img.sprite = sprite;

    // }

    // public void getPicture(string tokens)
    // {
    //     string url = "https://hack.lcpu.net/stable-diffusion/majicmix";
    //     var payload = new
    //     {
    //         prompt = tokens,
    //         steps = 20
    //     };
        
    //     using (WebClient client = new WebClient())
    //     {
    //         client.Headers[HttpRequestHeader.Authorization] = "Bearer eyJhbGciOiJFUzUxMiIsInR5cCI6IkpXVCJ9.eyJhZGRyIjoiNTEuNjguMTY5LjIyNSIsImVtYWlsIjoidGVhbTdAaGFjay5sY3B1Lm5ldCIsImV4cCI6MTY4NDU1NTQzMSwiaWF0IjoxNjg0NTU0NTMxLCJpc3MiOiJodHRwczovL2hhY2t1c2VyLmxjcHUubmV0L2xvZ2luIiwianRpIjoicDhjNHFtN0JXekJYNWllYnhmUWNrVUdZNlI3ZFRIRklIbkxxNW9ubmQiLCJuYmYiOjE2ODQ1NTQ0NzEsIm9yaWdpbiI6ImxvY2FsIiwicm9sZXMiOlsiYXV0aHAvdXNlciJdLCJzdWIiOiJ0ZWFtNyJ9.AWaplvTKNrGmVpvJ2K3YK5xS80EK_lNJIEwE2-N26Z73kc80W6q1jCbO6C8AqBI4OZd31apQWQf6Un6xL-fJLeMIAfHiUEAo9P1_fc9j-2VyWTxN_nu9XG2rX58fgIeJ8YYqF7V5s6lWz5TUrDMInPefaUtvFY6Nvjtboi6A1o8BFc2h";
    //         client.Headers[HttpRequestHeader.ContentType] = "application/json";
    //         string jsonPayload = JsonConvert.SerializeObject(payload);
    //         string response = client.UploadString($"{url}/stable-diffusion/majicmix/sdapi/v1/txt2img", jsonPayload);

    //         Debug.Log(response);
    //         dynamic r = JsonConvert.DeserializeObject(response);

    //         //Debug.Log(r.images[0]);
    //         byte[] imageBytes = Convert.FromBase64String(r.images[0].ToString().Split(",", 2)[0]);
           
    //         using (MemoryStream stream = new MemoryStream(imageBytes))
    //         {
           
    //             System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                
    //             image.Save("Assets/Resources/output.png");
    //         };

    //     }
    // }
}
