using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{

    public GameObject[] wayPoints;
    public static GameObject[] getPoint;
    public static GameObject[] currPoints;
    public static int index;
    public static int wayPointNum;
    public static float getDistance;
    public static Vector3 getDestination;
    public bool loop;
    public bool showPoints;
    public static bool moving;
    public float speed;
    // Start is called before the first frame update
    public void PointStart()
    {
        index = 0;
        currPoints = wayPoints;
        getDestination = wayPoints[index].transform.position;
        wayPointNum = wayPoints.Length;
        gameObject.SetActive(showPoints);
        moving = false;
    }

    private void Update()
    {
        getDestination = currPoints[index].transform.position;
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, getDestination, speed * Time.deltaTime);
            getDistance = Vector3.Distance(transform.position, getDestination);
            if (getDistance <= 0.05)
            {
                increaseIndex();
            }
        }
    }
    // Update is called once per frame
    public void increaseIndex()
    {
        if (loop)
        {
            if (index != wayPointNum - 1)
                index += 1;
            else
                if (index != 0)
                index -= 1;
        }
        else
        if (index != wayPointNum - 1)
            index += 1;
        else
            index += 0;

    }
    public static Vector3 getWayPoint(int position)
    {
        return currPoints[position].transform.position;
    }
    public GameObject[] getWaypoints()
    {
        return wayPoints;
    }
    public static void setPath(GameObject[] newPoints)
    {
        index = 0;
        for(int i = 0; i < newPoints.Length; i++)
        currPoints[i] = newPoints[i];
        getDestination = currPoints[index].transform.position;
        wayPointNum = newPoints.Length;
    }
}
