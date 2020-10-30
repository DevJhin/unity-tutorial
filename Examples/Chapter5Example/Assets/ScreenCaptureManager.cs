using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class ScreenCaptureManager : MonoBehaviour
{
    public string FolderPath;

    public CaptureMode captureMode;

    private Camera cam;


    public enum CaptureMode
    {
        Screen,
        Normal,
        Depth
    }


    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Capture();
        }
    }

    void Capture()
    {
        switch (captureMode)
        {
            case CaptureMode.Screen:
                ScreenCapture();
                break;
            case CaptureMode.Normal:
                NormalCapture();
                break;
            case CaptureMode.Depth:
                DepthCapture();
                break;
        }
    }

    private void ScreenCapture()
    {
        cam = Camera.main;

        int width = Screen.width;
        int height = Screen.height;

        RenderTexture rt = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32);
        rt.useMipMap = false;
        rt.antiAliasing = 1;

        cam.targetTexture = rt;
        cam.Render();
        RenderTexture.active = rt;

        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0, false);
        texture.Apply(false);

        WriteTexture(texture);

        //Reset settings.
        cam.targetTexture = null;
        RenderTexture.active = null;

        Destroy(texture);
        Destroy(rt);
    }

    private void WriteTexture(Texture2D texture)
    {
        byte[] pngData = texture.EncodeToPNG();

        var now = System.DateTime.Now;

        string fileName = "ScreenShot" + ' ' +".png";

        string folderPath = Application.dataPath + "/" + FolderPath;
        string filePath = folderPath+ '/' +fileName;

        if (!Directory.Exists(folderPath))
        { 
            Directory.CreateDirectory(folderPath);
        }

        Debug.Log(filePath);

        File.WriteAllBytes(filePath, pngData);
        
    }


    private void NormalCapture()
    {
       
    }

    private void DepthCapture()
    { 
    
    }
}
