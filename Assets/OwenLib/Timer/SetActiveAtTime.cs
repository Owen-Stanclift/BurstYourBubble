using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAtTime : MonoBehaviour
{
    public GameObject[] objects;
    public float seconds;
    public bool countDown;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown)
        {
            if (TimerSystem.time <= seconds)
            {
                if (RandomSceneSelection.isRandomScene)
                {
                    if(RandomSceneSelection.sceneMemory.Count == 0)
                    objects[2].SetActive(true);
                    else
                    objects[0].SetActive(true);
                }
                else
                    objects[1].SetActive(true);
               
            }
        }
        else
        {
            if (TimerSystem.time >= seconds)
            {
                if (RandomSceneSelection.isRandomScene)
                    objects[0].SetActive(true);
                else
                    objects[1].SetActive(true);

            }
        }

    }
}
