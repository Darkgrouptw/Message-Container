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

}
