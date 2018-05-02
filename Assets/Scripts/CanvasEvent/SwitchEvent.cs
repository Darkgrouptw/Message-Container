using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchEvent : MonoBehaviour
{
    public GameObject TextCanvas;
    public GameObject PhotoCanvas;
    public GameObject PressToRecordText;
	
    /// <summary>
    /// 轉道 Canvas
    /// </summary>
    public void SwitchToVoiceCanvas()
    {
        SwitchCanvasByBoolean(false, false, true);
    }

    public void SwtichToPhotoCanvas()
    {
        SwitchCanvasByBoolean(true, true, false);
    }

    public void SwitchToDefault()
    {
        SwitchCanvasByBoolean(true, false, true);
    }

    private void SwitchCanvasByBoolean(bool IsText = false, bool IsPhoto = false, bool IsShowRecordText = false)
    {
        TextCanvas.SetActive(IsText);
        PressToRecordText.SetActive(IsShowRecordText);
        PhotoCanvas.SetActive(IsPhoto);
    }
}
