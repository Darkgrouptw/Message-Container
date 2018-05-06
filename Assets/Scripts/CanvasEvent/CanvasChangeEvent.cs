using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text ContentText;
    public AudioSource Source;
    public RawImage Pic;


    [Header("========== 讀檔的部分 ==========")]
    private string readText;
    private AudioClip readVoice;
    private Texture2D readImage;

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

        
        #region 判斷有沒有東西存在
        string TextPath = Application.persistentDataPath + "/content.txt";
        string VoicePath = Application.persistentDataPath + "/Voice/voice.wav";
        string PhotoPath = Application.persistentDataPath + "/pic.jpg";
        bool IsTextExist = System.IO.File.Exists(TextPath);
		bool IsVoiceExist = System.IO.File.Exists(VoicePath);
        bool IsPhotoExist = System.IO.File.Exists(PhotoPath);
		Debug.Log ("Text Exist: " + IsTextExist.ToString ());
		Debug.Log ("Voice Exist: " + IsVoiceExist.ToString ());
		Debug.Log ("Photo Exist: " + IsPhotoExist.ToString ());
        #endregion
        #region 開始讀內容
        if (IsTextExist)
            LoadText(TextPath);
        if (IsVoiceExist)
            StartCoroutine(LoadVoice(VoicePath));
        if (IsPhotoExist)
            StartCoroutine(LoadImage(PhotoPath));
        #endregion
        #region 顯示 Canvas
        TextCanvas.SetActive(IsTextExist);
        VoiceCanvas.SetActive(IsVoiceExist);
        PicCanvas.SetActive(IsPhotoExist);
        #endregion
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

    public void PlaySource()
    {
        if(state == CanvasState.STATE_READ && !Source.isPlaying)
        {
            Source.Play();
        }
    }

    #region 讀檔的部分
    private void LoadText(string Path)
    {
        readText = System.IO.File.ReadAllText(Path);
        ContentText.text = readText;
    }

    private IEnumerator LoadVoice(string Path)
    {
        WWW www = new WWW(Path);
        while (!www.isDone)
            yield return new WaitForSeconds(0.2f);

        readVoice = www.GetAudioClip();
        Source.clip = readVoice;
    }

    private IEnumerator LoadImage(string Path)
    {
        WWW www = new WWW(Path);
        while (!www.isDone)
            yield return new WaitForSeconds(0.2f);

        readImage = www.texture;
        Pic.texture = readImage;
    }
    #endregion
}
