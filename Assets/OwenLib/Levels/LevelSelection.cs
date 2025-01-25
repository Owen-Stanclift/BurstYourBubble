using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update

    public static int currLevel;
    public void OnClickLevel(int levelNum)
    {
        currLevel = levelNum;
    }
}
