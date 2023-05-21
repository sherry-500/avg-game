using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public static UIManager2 Instance {get; private set;}

    public GameObject bg_img;

    private void Awake() {
        Instance = this;
    }

    public void updateImg(byte[] imageBytes){
        Debug.Log("updateImg");
        Texture2D imageTexture = new Texture2D(800, 450, TextureFormat.RGBA32, false, true);
        imageTexture.LoadImage(imageBytes);
        Sprite sp = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), Vector2.zero);
        bg_img.GetComponent<Image>().sprite = sp;
    }
}
