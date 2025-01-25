using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSceneSelection : MonoBehaviour
{

    public int[] scenes;
    public bool noRepeat;
    public bool fade;
    public static int currScene;
    public static List<int> sceneMemory = new List<int>();
    private MainMenu menu;
    public static bool isRandomScene = false;
    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<MainMenu>();
        RandomSceneList();
    }

    // Update is called once per frame
    void Update()
    {
        menu = FindObjectOfType<MainMenu>();
    }
    public void RandomSceneSelect()
    {
        isRandomScene = true;
        if (sceneMemory.Count == 0)
        {
            RandomSceneList();
        }
        else
        { 
            int index = Random.Range(0, sceneMemory.Count);
            currScene = sceneMemory[index];
            if (noRepeat)
            {
                sceneMemory.RemoveAt(index);
                if (!fade)
                    menu.SwitchScene(currScene);
                else
                    menu.SwitchSceneFade(currScene);
            }
            else
            {
                if (!fade)
                    menu.SwitchScene(currScene);
                else
                    menu.SwitchSceneFade(currScene);
            }
        }
    }
    public void RandomSceneSet()
    {
        if (sceneMemory.Count == 0)
        {
            RandomSceneList();
        }
            int index = Random.Range(0, sceneMemory.Count);
            currScene = sceneMemory[index];
            if (noRepeat)
            {
                sceneMemory.RemoveAt(index);
            }
            else
                return;

        isRandomScene = true;
    }

    public void SwitchToCurrScene()
    {
        menu.SwitchScene(currScene);
    }
    public void RandomSceneList()
    {
        isRandomScene = false;
        sceneMemory.Clear();
        for (int i = 0; i < scenes.Length; i++)
        {
            sceneMemory.Add(scenes[i]);
        }
    }

    public int GetCurrentScene()
    {
        return currScene;
    }
}
