using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Material blurMat;

    private void Start()
    {
        blurMat = new Material(Shader.Find("Custom/Blur"));
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(blurMat != null)
            Graphics.Blit(source, destination, blurMat);
    }
}
