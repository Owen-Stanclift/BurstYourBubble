using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager manager;
    public Slider musicSlider, sfxSlider;

    public static bool isSet;
    public static void ButtonSound()
    {
        manager.PlaySound(manager.buttonSound);
    }
    public static void WoodSound()
    {
        manager.PlaySound(manager.woodBreak);
    }
    public static void AxeStrikeSound()
    {
        manager.PlaySound(manager.axeStrike);
    }
    public static void AxeThrowSound()
    {
        manager.PlaySound(manager.axeThrow);
    }
    public static void SawSound()
    {
        manager.PlaySound(manager.saw);
    }
    public static void EndSound()
    {
        manager.PlaySound(manager.endSound);
    }
    public static void WhistleSound()
    {
        manager.PlaySound(manager.whistleSound);
    }
    public static void ResetSong()
    {
        manager.ResetMusic();
    }
    public static void Pause()
    {
        manager.PauseMusic();
    }
    public static void Resume()
    {
        manager.ResumeMusic();
    }
    public static void Play()
    {
        manager.playBackground = true;
        manager.PlayMusic(manager.backgroundMusic);
    }
    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        manager.setMusicVolume(volume);
    }
    public void setSFXVolume()
    {
        float volume = sfxSlider.value;
        manager.setSFXVolume(volume);
    }
    // Update is called once per frame
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }
}
