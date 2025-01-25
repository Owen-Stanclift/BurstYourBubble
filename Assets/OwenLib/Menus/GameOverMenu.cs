using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameObject.IsDestroyed())
            {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0.0f;
            TimeLoop.isPaused = true;
        }
    }
}
