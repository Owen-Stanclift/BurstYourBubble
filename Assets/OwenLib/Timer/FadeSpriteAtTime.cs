using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSpriteAtTime : MonoBehaviour
{
    public GameObject[] objects;
    public bool isFadeOut;
    public float fadeDuration;
    public float seconds;
    public bool countDown;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        if(!isFadeOut)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<SpriteRenderer>().color = new Color(objects[i].GetComponent<SpriteRenderer>().color.r, objects[i].GetComponent<SpriteRenderer>().color.g, objects[i].GetComponent<SpriteRenderer>().color.b, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeOut)
        {
            if (TimerSystem.time <= seconds)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    Color newColor = new Color(objects[i].GetComponent<SpriteRenderer>().color.r, objects[i].GetComponent<SpriteRenderer>().color.g, objects[i].GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(1, 0, time / fadeDuration));
                    time += Time.deltaTime;
                    objects[i].GetComponent<SpriteRenderer>().color = newColor;
                    if (objects[i].GetComponent<SpriteRenderer>().color.a == 0)
                    {
                        objects[i].SetActive(false);
                    }
                }

            }
        }
        else
        {
            if (TimerSystem.time >= seconds)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    Color newColor = new Color(objects[i].GetComponent<SpriteRenderer>().color.r, objects[i].GetComponent<SpriteRenderer>().color.g, objects[i].GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(0, 1, time / fadeDuration));
                    time += Time.deltaTime;
                    objects[i].GetComponent<SpriteRenderer>().color = newColor;
                }

            }
        }
    }
}
