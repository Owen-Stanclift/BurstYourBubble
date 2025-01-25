using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    public WaypointSystem waypoint;
    // Start is called before the first frame update
    void Start()
    {
        waypoint.PointStart();
        WaypointSystem.moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
