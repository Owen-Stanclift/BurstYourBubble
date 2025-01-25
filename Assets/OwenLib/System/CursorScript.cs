using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public bool showTrail;
    private TrailRenderer trailRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (showTrail)
        {
            GetComponent<TrailRenderer>().enabled = true;
            trailRenderer = GetComponent<TrailRenderer>();
        }
        else
        {
            GetComponent<TrailRenderer>().enabled = false;
        }
        Cursor.visible = false;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += 1;
        gameObject.transform.position = mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += 1;
        gameObject.transform.position = mousePosition;
        //Debug.Log(mousePosition);
    }

   public void ChangeCursor(int index)
    {
        gameObject.GetComponent<SpriteManager>().setSprite(index);
    }
    
}
