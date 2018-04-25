using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchEvent : MonoBehaviour
{
    public GameObject TextCanvas;
    public GameObject VoiceCanvas;
    public GameObject PhotoCanvas;
	
    /// <summary>
    /// 轉道 Canvas
    /// </summary>
    public void SwitchToVoiceCanvas()
    {
        SwitchCanvasByBoolean(false, true, false);
    }

    public void SwtichToPhotCanvas()
    {
        SwitchCanvasByBoolean(false, false, true);
    }

    private void SwitchCanvasByBoolean(bool IsText = false, bool IsVoice = false, bool IsPhoto = false)
    {
        TextCanvas.SetActive(IsText);
        VoiceCanvas.SetActive(IsVoice);
        PhotoCanvas.SetActive(IsPhoto);
    }
}
