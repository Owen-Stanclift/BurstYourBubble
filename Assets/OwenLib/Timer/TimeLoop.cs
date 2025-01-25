using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TimeLoop : MonoBehaviour
{
    public static float time;
    public static bool timeRunning;
    public float timeLoopSeconds;
    public static float totalLoop;
    public static float minutes;
    public static float seconds;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        timeRunning = true;
        totalLoop = timeLoopSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            minutes = Mathf.FloorToInt(time / 60);
            seconds = Mathf.FloorToInt(time % 60);
            if (seconds == timeLoopSeconds)
            {
                time = 0;
            }
            if (timeRunning)
            {
                time += Time.deltaTime;
            }
        }
    }
    public static void DisplayTime(TMP_Text timeText)
    {
        timeText.text = minutes + ":" + seconds;
    }
}
