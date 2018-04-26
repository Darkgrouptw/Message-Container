using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChangeEvent : MonoBehaviour
{
    [Header("========== Canvas ==========")]
    public GameObject MainCanvas;
    public GameObject AddMessageCanvas;

    public GameObject ARCamera;

    public void MainToAddMessage()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        MainCanvas.SetActive(false);
        AddMessageCanvas.SetActive(true);

        //ARCamera.SetActive(false);
    }

    public void BackToMain()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;

        MainCanvas.SetActive(true);
        AddMessageCanvas.SetActive(false);

        //ARCamera.SetActive(true);
    }
}
