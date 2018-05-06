using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButtonEvent : MonoBehaviour
{
    //[]
    public InputField contentText;


    public void SaveContentText()
    {

		string SaveLocation = Application.persistentDataPath + "/content.txt";
		System.IO.File.WriteAllText(SaveLocation,contentText.text);
		Debug.Log ("寫入檔案: " + SaveLocation);
    }
}
