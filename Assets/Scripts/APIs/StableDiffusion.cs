using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class StableDiffusion
{
    private string api_url;

    private int index = 0;
    public IEnumerator getPicture(string tokens, Action<byte[]> callback)
    {
        if (api_url == null) api_url = MyConfig.ResolveLocalFileAuthArgs("stable_diffusion_url");
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
            callback(imageBytes);
            index ++;
        }
    }
}
