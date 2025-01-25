using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("-----Audio Sources-----")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    [Header("-----Music-----")]
    public bool playBackground;
    public AudioClip backgroundMusic;
    [Header("-----SFX-----")]
    public bool playSFX;
    public AudioClip buttonSound;
    public AudioClip woodBreak;
    public AudioClip axeStrike;
    public AudioClip axeThrow;
    public AudioClip saw;
    public AudioClip endSound;
    public AudioClip whistleSound;

    public static bool isSet;
    private void Awake()
    {
        musicSource.volume = 1;
        sfxSource.volume = 1;
        if(playBackground)
        PlayMusic(backgroundMusic);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    public void PlayMusic(AudioClip clip)
    {
        if (playBackground)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }
    public void ResetMusic()
    {
        if (playBackground)
        {
            musicSource.Stop();
            musicSource.Play();
        }
    }
    public void ResumeMusic()
    {
        if (playBackground)
        {
            if (!musicSource.isPlaying)
                musicSource.Play();
        }
    }
    public void PauseMusic()
    {
        if (playBackground)
        {
            if (musicSource.isPlaying)
            {
                musicSource.Pause();
            }
        }
    }
    public void PlaySound(AudioClip clip)
    {
        if(playSFX)
       sfxSource.PlayOneShot(clip);
     
    }
    public void PlaySoundButton()
    {
       if(playSFX)
       sfxSource.PlayOneShot(buttonSound);
    }
    public void setMusicVolume(float volume)
    {
        if (playBackground)
        {
            musicSource.volume = volume;
        }
    }
    public void setSFXVolume(float volume)
    {
        if (playSFX)
        {
            sfxSource.volume = volume;
        }
    }
}
