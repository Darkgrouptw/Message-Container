using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum RecordingState
{
    Normal = 0,
    IsRecording,
    EndingRecording,
    PlayingRecording,
}

public class RecordButtonManager : MonoBehaviour
{
    // 圖片
    [Header("========== 圖片 ==========")]
    public Sprite DefaultImg;
    public Sprite RecordBG;
    public Sprite DisableImg;


    // 物件
    [Header("========= 物件 =========")]
    public Image RecordButton;
    public GameObject PlayObject;
    public Text textObject;

    // 錄音相關
    [Header("========= 錄音部分 =========")]
    public AudioSource testSource;
    private AudioClip MicrophoneClip = null;
    private string MicrophoneDeviceName = "";
    private float RecordingTime = 0;
    private const int MaximumRecordingTime = 60 * 10;       //10 mins
    private string SaveLocation;

    // 狀態
    private RecordingState state = RecordingState.Normal;

    private void Start()
    {
        // 拿錄音的裝置
        if (Microphone.devices.Length > 0)
        {
            MicrophoneDeviceName = Microphone.devices[0];
            Debug.Log(MicrophoneDeviceName);
        }
        else
            Debug.LogError("沒有麥克風!!");

        // 存檔路徑
        SaveLocation = Application.persistentDataPath + "/Voice/voice.wav";
        Debug.Log("錄音:" + SaveLocation);
    }
    private void Update()
    {
        switch(state)
        {
            case RecordingState.IsRecording:
                RecordingTime += Time.deltaTime;
                textObject.text = TransfromToTimeFormat(RecordingTime);
                break;
            case RecordingState.PlayingRecording:
                if (!testSource.isPlaying)
                    state = RecordingState.EndingRecording;
                break;
        }
    }

    #region 按鈕事件
    public void ButtonDown()
    {
        switch(state)
        {
            case RecordingState.Normal:
                SwitchToRecording();
                state = RecordingState.IsRecording;
                break;
            case RecordingState.EndingRecording:
                PlayRecording();
                state = RecordingState.PlayingRecording;
                break;
        }
    }
    public void ButtonUp()
    {
        switch(state)
        {
            case RecordingState.IsRecording:
                EndRecording();
                state = RecordingState.EndingRecording;
                break;
        }
    }
    #endregion

    // 還原
    public void ResetAll()
    {
        state = RecordingState.Normal;
        RecordingTime = 0;
        SwitchToDefault();
    }

    #region 按鍵圖片切換 Function
    private void SwitchToDefault()
    {
        RecordButton.sprite = DefaultImg;
    }
    private void SwitchToRecording()
    {
        RecordButton.sprite = RecordBG;

        // 設定其他部分
        textObject.gameObject.SetActive(true);
        textObject.GetComponent<Text>().text = "00:00";

        // 清空
        RecordingTime = 0;

        // 錄音
        if(MicrophoneDeviceName != "")
            MicrophoneClip = Microphone.Start(MicrophoneDeviceName, false, MaximumRecordingTime, AudioSettings.outputSampleRate);
    }
    private void SwitchToDisable()
    {
        RecordButton.sprite = DisableImg;
    }
    #endregion
    #region 錄音相關
    private void EndRecording()
    {
        PlayObject.SetActive(true);

        // 停止錄音
        Microphone.End(MicrophoneDeviceName);

        // 只拿取錄音的部分
        MicrophoneClip = MakeSubclip(MicrophoneClip, 0, RecordingTime);
        SavWav.Save(SaveLocation, MicrophoneClip);
    }

    // 播聲音
    private void PlayRecording()
    {
        state = RecordingState.PlayingRecording;
        if(MicrophoneDeviceName !=  "")
        {
            testSource.clip = MicrophoneClip;
            testSource.Play();
        }
    }
    #endregion
    #region Helper Function
    private string TransfromToTimeFormat(float t)
    {
        int second = (int)t;
        int minutes = second / 60;
        return minutes.ToString("00") + ":" + second.ToString("00");
    }

    private AudioClip MakeSubclip(AudioClip clip, float start, float stop)
    {
        int frequency = clip.frequency;
        float timeLength = stop - start;
        int samplesLength = (int)(frequency * timeLength);

        AudioClip newClip = AudioClip.Create(clip.name + "-sub", samplesLength, 1, frequency, false);

        float[] data = new float[samplesLength];
        clip.GetData(data, (int)(frequency * start));
        newClip.SetData(data, 0);

        return newClip;
    }
    #endregion
}
