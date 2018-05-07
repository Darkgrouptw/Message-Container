using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrentDate : MonoBehaviour {
    // 顯示現在時間的文字
    public Text CurrentDateText;

	private void Start ()
    {
        string FormatedTime = System.DateTime.Now.ToString("yyyy.MM.dd");
        //Debug.Log(FormatedTime);
        if (CurrentDateText != null)
            CurrentDateText.text = FormatedTime;
        else
            Debug.Log("沒有文字可以改時間!!");
	}

	public void ClearFile()
	{
		string TextPath = Application.persistentDataPath + "/content.txt";
		string VoicePath = Application.persistentDataPath + "/Voice/voice.wav";
		string PhotoPath = Application.persistentDataPath + "/pic.jpg";
		System.IO.File.Delete (TextPath);
		System.IO.File.Delete (VoicePath);
		System.IO.File.Delete (PhotoPath);
		Debug.Log ("Delete File Success");
	}
}
