using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

   
{
    public GameObject pauseMenu;
    public GameObject button;
    private PlaySound sound;
    public bool isPaused;
    public void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
        {
           PauseGame();
        }
    }
    public void PauseGame()
    {
        if (isPaused)
        {
            button.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
            PlaySound.Resume();
            TimeLoop.isPaused = false;
        }
        else
        {
            button.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
            isPaused = true;
            PlaySound.Pause();
            TimeLoop.isPaused = true;
        }
    }
 
}
