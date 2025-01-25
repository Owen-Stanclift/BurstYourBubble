using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicAtTime : MonoBehaviour
{
    public float playAtTime;
    public bool sfx;
    public bool countDown;
    private bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!countDown)
        {
            if (!sfx)
            {
                if (TimerSystem.time >= playAtTime && !played)
                {
                    played = true;
                    PlaySound.Play();
                }
            }
            else
            {
                if (TimerSystem.time >= playAtTime && !played)
                {
                    played = true;
                    PlaySound.WhistleSound();
                }
            }
        }
        else
        {
            if (!sfx)
            {
                if (TimerSystem.time <= playAtTime && !played)
                {
                    played = true;
                    PlaySound.Play();
                }
            }
            else
            {
                if (TimerSystem.time <= playAtTime && !played)
                {
                    played = true;
                    PlaySound.WhistleSound();
                }
            }
        }
    }
}
