using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public CursorScript cursor;
    public bool onlyWhenPressed;
    public static bool cursorIsMade;
    private GameObject cursorObject;
    // Start is called before the first frame update
    void Start()
    {
        if(!onlyWhenPressed)
        Instantiate(cursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (onlyWhenPressed)
        {
         
            if (Input.GetMouseButtonDown(0))
            {
                if (!cursorIsMade)
                {
                   cursorObject = Instantiate(cursor.gameObject);
                   cursorIsMade = true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (cursorIsMade)
                {
                    cursorIsMade = false;
                    Destroy(cursorObject);
                }
            }
        }
    }

    public bool GetCursorState()
    {
        return cursorIsMade;
    }
}
