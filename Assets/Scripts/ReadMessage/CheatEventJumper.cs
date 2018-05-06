using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum JumperState
{
    STATE_INIT = 0,     // 要等時間停下來
    STATE_DETECT,       // 偵測是否有
    STATE_ON,
}

public class CheatEventJumper : MonoBehaviour
{
    [Header("========== 狀態部分 ==========")]
    private JumperState state = JumperState.STATE_INIT;
    private const int FixToReadMessageTime = 2;


    [Header("========== 延遲部分 ==========")]
    private float TimeCounter = 0;
    private const int DelayForVuforiaTime = 1;
    private const int OnStatusTime = 10;

    private void Update()
    {
        switch (state)
        {
            case JumperState.STATE_INIT:
                TimeCounter += Time.deltaTime;
                if(TimeCounter >= DelayForVuforiaTime)
                {
                    state = JumperState.STATE_DETECT;
                    TimeCounter = 0;
                }
                break;
            case JumperState.STATE_DETECT:
                if(Input.touchCount >= 2)
                {
                    TimeCounter += Time.deltaTime;
                    if(TimeCounter >= FixToReadMessageTime)
                    {
                        state = JumperState.STATE_ON;
                        TimeCounter = 0;
                    }
                }
                else
                {
                    TimeCounter = 0;
                }
                break;
            case JumperState.STATE_ON:
                // 這邊持續 OnStatusTime 秒就結束了
                TimeCounter += Time.deltaTime;
                if (TimeCounter >= OnStatusTime)
                {
                    TimeCounter = 0;
                    state = JumperState.STATE_INIT;
                }
                else if (Input.touchCount >= 2)
                    TimeCounter = 0;
                break;
        }

    }

    public bool IsSwitchOn()
    {
        if (state == JumperState.STATE_ON)
            return true;
        return false;
    }
}
