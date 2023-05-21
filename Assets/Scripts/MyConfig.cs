using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class MyConfig
{
    public static string ResolveLocalFileAuthArgs(string str)
	{
		string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		string authPath = $"{userPath}/.newchat/auth.json";
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
		return result[str];
	}
}
