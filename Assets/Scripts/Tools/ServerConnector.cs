using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

enum SendType
{
	TYPE_TEXT = 0,
	TYPE_VOICE,
	TYPE_IMG,
};

public class ServerConnector : MonoBehaviour 
{
	//private string IP ="http://172.20.10.9:8081/";
	private string IP = "https://httpbin.org/put";
	private SendType type= SendType.TYPE_TEXT;
	private string content;

	// 傳送圖片位置
	public void SendTextMessage(InputField field)
	{
		//type = SendType.TYPE_TEXT;
		//content = field.text;

		//StartCoroutine (SendRequest ());
	}

	// 傳送聲音
	public void SendVoiceMessage()
	{
	}

	// 傳送圖片
	public void SendImgMessage(string base64Str)
	{
		//type = SendType.TYPE_TEXT;
		//content = base64Str;
		//StartCoroutine (SendRequest ());
	}

	/*private IEnumerator SendRequest() {
		string PostURL = IP;
		switch (type) 
		{
		case SendType.TYPE_TEXT:
			//PostURL += "text";
			break;
		case SendType.TYPE_IMG:
			//PostURL += "image";
			break;
		}
		Debug.Log (PostURL);
		Debug.Log (content);
		UnityWebRequest www = UnityWebRequest.Put(PostURL, content);
		//www.chunkedTransfer = false;
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log("Server: " + www.error.ToString());
		}
		else {
			Debug.Log("Server: " + www.downloadHandler.text);
		}
	}*/
}
