using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CanvasState
{
    STATE_MAIN = 0,
    STATE_ADD,
    STATE_READ
}


public class CanvasChangeEvent : MonoBehaviour
{
    [Header("========== Canvas ==========")]
    public GameObject MainCanvas;
    public GameObject AddMessageCanvas;
    public GameObject ReadMessageCanvas;

    public GameObject ARCamera;

    [Header("========== 讀訊息的部分 ==========")]
    public MeshRenderer CubeMeshRender;
    public CheatEventJumper jumper;
    public GameObject TextCanvas;
    public GameObject VoiceCanvas;
    public GameObject PicCanvas;

    private CanvasState state = CanvasState.STATE_MAIN;

    private void Update()
    {
        if(state == CanvasState.STATE_MAIN)
        {
            // 這邊有兩種狀態會跳過去
            if(jumper.IsSwitchOn() || CubeMeshRender.enabled)
            {
                MainToReadMessage();
            }
        }
        else if(state == CanvasState.STATE_READ)
        {
            // 跳回來的部分
            if (!jumper.IsSwitchOn() && !CubeMeshRender.enabled)
                BackToMain();
        }
    }

    public void MainToAddMessage()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        MainCanvas.SetActive(false);
        AddMessageCanvas.SetActive(true);

        // 狀態
        state = CanvasState.STATE_ADD;
    }

    public void MainToReadMessage()
    {
        MainCanvas.SetActive(false);
        ReadMessageCanvas.SetActive(true);

        // 狀態
        state = CanvasState.STATE_READ;


        // 判斷有沒有東西存在
        //if(System.IO.File.Exists( Application.persistentDataPath + "/Voice/voice.wav"))
        //{

        //}
        bool IsPhotoExist = System.IO.File.Exists(Application.persistentDataPath + "/pic.jpg");
        bool IsVoiceExist = System.IO.File.Exists(Application.persistentDataPath + "/Voice/voice.wav");
        bool IsTextExist = System.IO.File.Exists(Application.persistentDataPath + "/content.txt");
        TextCanvas.SetActive(IsTextExist);
        VoiceCanvas.SetActive(IsVoiceExist);
        PicCanvas.SetActive(IsPhotoExist);
    }

    public void BackToMain()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;

        MainCanvas.SetActive(true);
        AddMessageCanvas.SetActive(false);
        ReadMessageCanvas.SetActive(false);

        // 狀態
        state = CanvasState.STATE_MAIN;
    }
}
