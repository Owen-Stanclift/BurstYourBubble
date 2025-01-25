using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAtTime : MonoBehaviour
{
    public bool fadeOut;
    public float fadeOutDuration;
    public float fadeOutTime;
    public bool fadeIn;
    public float fadeInDuration;
    public float fadeInTime;
    public bool countDown;
    private float time;
    private bool isAppear = true;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        if (!fadeOut)
        {
            isAppear = false;
            gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut && fadeIn)
        {
            if (TimerSystem.time >= fadeOutTime && isAppear)
            {
                    Color newColor = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, Mathf.Lerp(1, 0, time / fadeOutDuration));
                    time += Time.deltaTime;
                    gameObject.GetComponent<Image>().color = newColor;
                    if (gameObject.GetComponent<Image>().color.a == 0)
                    {
                        time = 0;
                        isAppear = false;
                    }

            }
            if (TimerSystem.time >= fadeInTime && !isAppear)
            {
                    Color newColor = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, Mathf.Lerp(0, 1, time / fadeInDuration));
                    time += Time.deltaTime;
                    gameObject.GetComponent<Image>().color = newColor;

            }
        }
        else
        {
            if (fadeOut)
            {
                if (TimerSystem.time >= fadeOutTime && isAppear)
                {
                        Color newColor = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, Mathf.Lerp(1, 0, time / fadeOutDuration));
                        time += Time.deltaTime;
                        gameObject.GetComponent<Image>().color = newColor;
                        if (gameObject.GetComponent<Image>().color.a == 0)
                        {
                        gameObject.SetActive(false);
                        isAppear=false;
                        }
                    }
            }
            else
            {
                if (TimerSystem.time >= fadeInTime)
                {
                        Color newColor = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, Mathf.Lerp(0, 1, time / fadeInDuration));
                        time += Time.deltaTime;
                    gameObject.GetComponent<Image>().color = newColor;

                }
            }
        }
    }
}
