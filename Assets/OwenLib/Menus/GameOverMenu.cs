using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject player;
    public Scene gameOverMenu;

    // Update is called once per frame
    void Update()
    {
        if(player.gameObject.IsDestroyed())    
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 0.0f;
            TimeLoop.isPaused = true;
        }
    }
}
