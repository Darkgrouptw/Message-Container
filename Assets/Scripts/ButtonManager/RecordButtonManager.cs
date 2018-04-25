using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    #region 按鍵圖片切換 Function
    private void SwitchToDefault()
    {
        RecordButton.sprite = DefaultImg;
    }
    private void SwitchToRecording()
    {
        RecordButton.sprite = RecordBG;
    }
    public void SwitchToDisable()
    {
        RecordButton.sprite = DisableImg;
    }
    #endregion
}
