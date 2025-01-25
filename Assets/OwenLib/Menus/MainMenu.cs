using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeScreen;
    public float fadeInDuration;
    public int tutorialIndex;
    public int[] sceneWithTutorialIndex;
    public static int currScene;
    public static bool showTutorial = true;
    private bool startFade = false;
    private float time = 0;
    private int mScene;

    private void Update()
    {
        if(startFade && fadeScreen != null)
        {
            Color newColor = new Color(fadeScreen.GetComponent<Image>().color.r, fadeScreen.GetComponent<Image>().color.g, fadeScreen.GetComponent<Image>().color.b, Mathf.Lerp(0, 1, time / fadeInDuration));
            time += Time.deltaTime;
            fadeScreen.GetComponent<Image>().color = newColor;
            if (fadeScreen.GetComponent<Image>().color.a == 1)
            {
                Time.timeScale = 1.0f;
                TimerSystem.time = 0;
                TimeLoop.isPaused = false;
                AudioListener.pause = false;
                startFade = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + mScene);
            }
        }
    }
    public void SwitchScene(int sceneNumTo)
    {
        int sceneNum = sceneNumTo - SceneManager.GetActiveScene().buildIndex;
        if (showTutorial)
        {
            for (int i = 0; i < sceneWithTutorialIndex.Length; i++)
            {
                if (sceneNumTo == sceneWithTutorialIndex[i])
                {
                    sceneNum = tutorialIndex - SceneManager.GetActiveScene().buildIndex;
                    currScene = sceneNumTo;
                }
            }
        }
            Time.timeScale = 1.0f;
            TimerSystem.time = 0;
            TimeLoop.isPaused = false;
            AudioListener.pause = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNum);
    }
    public void SwitchSceneFade(int sceneNumTo)
    {
        if (fadeScreen != null)
        {
            fadeScreen.SetActive(true);
            fadeScreen.GetComponent<Image>().color = new Color(fadeScreen.GetComponent<Image>().color.r, fadeScreen.GetComponent<Image>().color.g, fadeScreen.GetComponent<Image>().color.b, 0);
            mScene = sceneNumTo - SceneManager.GetActiveScene().buildIndex;
            if (showTutorial)
            {
                for (int i = 0; i < sceneWithTutorialIndex.Length; i++)
                {
                    if (sceneNumTo == sceneWithTutorialIndex[i])
                    {
                        mScene = tutorialIndex - SceneManager.GetActiveScene().buildIndex;
                        currScene = sceneNumTo;
                    }
                }
            }
            startFade = true;
        }
    }
    public void SwitchToCurrScene()
    {
            int sceneNum = currScene - SceneManager.GetActiveScene().buildIndex;
            Time.timeScale = 1.0f;
            TimerSystem.time = 0;
            TimeLoop.isPaused = false;
            AudioListener.pause = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNum);
    }
    public void SwitchToCurrSceneFade()
    {
        int sceneNum = currScene - SceneManager.GetActiveScene().buildIndex;
        fadeScreen.SetActive(true);
        fadeScreen.GetComponent<Image>().color = new Color(fadeScreen.GetComponent<Image>().color.r, fadeScreen.GetComponent<Image>().color.g, fadeScreen.GetComponent<Image>().color.b, 0);
        mScene = sceneNum;
        startFade = true;
    }

    public void ToggleTutorial(Toggle toggle)
    {
        showTutorial = toggle.isOn;
    }

    public void QuitGame()
    {
        Application.Quit();
       // EditorApplication.isPlaying = false;
    }
 
}
