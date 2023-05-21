using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class StableDiffusion
{
    private string api_url = "https://u6370-b1ae-f97271ae.neimeng.seetacloud.com:6443";

    private int index = 0;
    public IEnumerator getPicture(string tokens, Action<byte[]> callback)
    {
        Debug.Log("getPicture: " + tokens);

        var payload = new
        {
            prompt = "(((best quality))),(((ultra detailed))),(((masterpiece))),illustration," + tokens,
            steps = 20,
            width = 800,
            height = 450,
            negative_prompt = "nsfw, (worst quality, low quality:1.4), (jpeg artifacts:1.4), (depth of field, bokeh, blurry, film grain, chromatic aberration, lens flare:1.0), greyscale, monochrome, emphasis lines, text, title, logo, signature, bad anatomy",
        };

        
        using (WebClient client = new WebClient())
        {
            yield return client;
            string jsonPayload = JsonConvert.SerializeObject(payload);
            string response = client.UploadString($"{api_url}/sdapi/v1/txt2img", jsonPayload);
            dynamic r = JsonConvert.DeserializeObject(response);
            byte[] imageBytes = Convert.FromBase64String(r.images[0].ToString().Split(",", 2)[0]);

            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                image.Save("Assets/Resources/output_" + index + ".png");
                callback(imageBytes);
                index ++;
            };
        }
    }
}
