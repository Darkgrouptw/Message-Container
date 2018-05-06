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
        System.IO.File.WriteAllText(Application.persistentDataPath + "/content.txt",contentText.text);
    }
}
