using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    public GameObject[] objects;
    public float seconds;
    public bool countDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown)
        {
            if (TimerSystem.time <= seconds)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].SetActive(false);
                }

            }
        }
        else
        {
            if (TimerSystem.time >= seconds)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].SetActive(false);
                }

            }
        }
    }
}
