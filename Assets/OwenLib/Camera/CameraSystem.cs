using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public static float width, height;
    public bool centerOnPlayer;
    public GameObject Player;
    public float distanceFromPlayer;
    private Vector3 pos;
    void Start()
    {
        height = 2f* cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (centerOnPlayer && Player != null)
        {
            pos = new Vector3(Player.transform.position.x, Player.transform.position.y, -distanceFromPlayer);
            cam.transform.position = pos;
        }
    }
}
