using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoButtonManager : MonoBehaviour
{
    [SerializeField]
	private Kakera.Unimgpicker imgPicker;

    // 物件
    [Header("========= 物件 =========")]
    public GameObject DisableRecordButton;
    public GameObject Photo;

    private bool IsPressOnce = false;

	[SerializeField]
    private Texture2D textureImg;

    private void Awake()
    {
        imgPicker.Completed += (string path) =>
        {
            StartCoroutine(LoadImage(path));
        };
    }

    // 還原
    public void ResetAll()
    {
        IsPressOnce = false;
        DisableRecordButton.SetActive(false);
    }

    #region 按鈕事件
    public void PhotoButtonDown()
    {
        if (!IsPressOnce)
        {
            IsPressOnce = true;
            DisableRecordButton.SetActive(true);
        }
    }

	// 圖片中，按加的時候會產生的事件
	public void PhotoPickerShow()
	{
		imgPicker.Show("Select Image", "unimgpicker", 1024);
	}
    #endregion
    #region Helper Function
    private IEnumerator LoadImage(string path)
    {
        string url = "file://" + path;
        WWW www = new WWW(url);
        yield return www;

        textureImg = www.texture;
        if (textureImg == null)
            Debug.LogError("讀取失敗: " + url);
		Debug.Log (textureImg.height);

        // 覆蓋圖片
        Photo.GetComponent<RawImage>().texture = textureImg;
    }
    #endregion
}
