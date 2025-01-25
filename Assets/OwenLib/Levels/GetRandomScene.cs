using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomScene : MonoBehaviour
{
    private RandomSceneSelection randomScene;
    // Start is called before the first frame update
    void Start()
    {
        randomScene = FindObjectOfType<RandomSceneSelection>();
    }

    public void RandomScene()
    {
        randomScene.RandomSceneSelect();
    }
    public void SetRandomScene()
    {
        randomScene.RandomSceneSet();
    }
    public void SwitchToSetScene()
    {
        randomScene.SwitchToCurrScene();
    }
    public void ResetRandomScene()
    {
        randomScene.RandomSceneList();
    }

    public int GetCurrScene()
    {
        return randomScene.GetCurrentScene();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
