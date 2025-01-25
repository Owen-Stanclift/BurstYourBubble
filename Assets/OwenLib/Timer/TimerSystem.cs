using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    public bool countDown;
    public static bool getCountDown;
    public float countDownSeconds;
    // Start is called before the first frame update
    public static float time;
    public static bool timeRunning;
    //public static float minutes;
    public static float seconds;
    public static float milliseconds;
    public static float minuteMark;
    public static float secondMark;
    public static float millisecondMark;
    void Start()
    {
        getCountDown = countDown;
        if (countDown)
        {
            time = countDownSeconds;
            while (countDownSeconds > 60)
            {
                minuteMark += 1;
                countDownSeconds -= 60;
            }
            secondMark = countDownSeconds;
        }
        else
        {
            minuteMark = 0;
            secondMark = 0;
        }
        millisecondMark = 0;
        timeRunning = true;

    }

    // Update is called once per frame
    void Update()
    {
        //minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        milliseconds = Mathf.FloorToInt(time * 1000) % 100;
         
        if (timeRunning)
        {
            if (countDown && time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            time += Time.deltaTime;
        }

    }
    public static void DisplayTime(TMP_Text timeText)
    {
        timeText.text = "Time: " + /*minutes + ":" +*/ seconds + " s";
    }
    public static void DisplayTimeMilliseconds(TMP_Text timeText)
    {
        timeText.text = /*minutes + ":" +*/ seconds + ":" + milliseconds + " s";
    }

    public static void ConvertTimeMark(string timeText)
    {
        string[] split;
        split = timeText.Split(':');
        minuteMark = int.Parse(split[0]);
        secondMark = int.Parse(split[1]);
    }
    public static void ConvertTimeMarkMilliseconds(string timeText)
    {
        string[] split;
        split = timeText.Split(':');
        minuteMark = int.Parse(split[0]);
        secondMark = int.Parse(split[1]);
        millisecondMark = int.Parse(split[2]);
    }
}
