using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text timeText;
    public bool showTime;
    public bool showMilliSeconds;
    public bool loop;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (showTime)
        {
            if (loop)
            {
                TimeLoop.DisplayTime(timeText);
            }
            else
                if (!showMilliSeconds)
                TimerSystem.DisplayTime(timeText);
            else
                TimerSystem.DisplayTimeMilliseconds(timeText);
        }
    }
}
