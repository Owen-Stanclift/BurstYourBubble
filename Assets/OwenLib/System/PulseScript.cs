using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    public static float pulseRate;
    public float speed;
    public static float pulseSpeed;
    public static float pulseMid;
    public static bool isPulse;
    public float growth;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        pulseMid =  (TimeLoop.totalLoop/2);
        originalScale = transform.localScale;
        isPulse = false;
        pulseSpeed = speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeLoop.isPaused)
        {
            if (TimeLoop.time >= pulseMid - speed && TimeLoop.time < pulseMid)
            {
                isPulse = true;
                transform.localScale = new Vector3(transform.localScale.x + growth, transform.localScale.y + growth, transform.localScale.z + growth);
            }
            else if (TimeLoop.time >= pulseMid && TimeLoop.time <= pulseMid + speed)
            {
                isPulse = true;
                transform.localScale = new Vector3(transform.localScale.x - growth, transform.localScale.y - growth, transform.localScale.z - growth);
            }
    
            else
                isPulse = false;
            }
     }
 }
