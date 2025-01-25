using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    // Start is called before the first frame update
    void Start()
    {
        levels[LevelSelection.currLevel].SetActive(true);
        TimerSystem.time = 0;
        Time.timeScale = 1.0f;
        TimeLoop.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
