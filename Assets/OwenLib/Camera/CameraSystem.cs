using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public static float width, height;
    void Start()
    {
        height = 2f* cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
