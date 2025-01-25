using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAtTime : MonoBehaviour
{
    public int scene;
    public bool random;
    public bool fade;
    public GetRandomScene randomSelection;
    public float switchAtSeconds;
    public static int sceneIndex;
    private MainMenu menu;
    private bool startFade = false;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        menu = FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerSystem.getCountDown == true)
        {
            if (TimerSystem.time <= switchAtSeconds && !startFade)
            {
                {
                    if (random && randomSelection != null)
                        randomSelection.RandomScene();
                    else
                    {
                        if (fade)
                        {
                            menu.SwitchSceneFade(scene);
                            startFade = true;
                        }
                        else
                            menu.SwitchScene(scene);
                    }
                }
            }
        }
        else
        {
            if (TimerSystem.time >= switchAtSeconds && !startFade)
            {
                if (random && randomSelection != null)
                    randomSelection.RandomScene();
                    else
                    {
                    if (fade)
                    {
                        menu.SwitchSceneFade(scene);
                        startFade = true;
                    }
                    else
                            menu.SwitchScene(scene);
                    }
            }
        }
    }
}
