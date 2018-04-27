using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public RenderTexture DownSampleTexture;
	private Camera ARCamera;

	private void Start()
	{
		ARCamera = this.GetComponent<Camera>();	
	}

	public void SetSampleTexture()
    {
		// 設定 DownSample
		ARCamera.targetTexture = DownSampleTexture;
    }

	public void ResetCameraTexture()
	{
		// 清空 Target Texture
		ARCamera.targetTexture = null;
	}
}
