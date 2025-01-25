using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public float forcePower;
    private GameObject cursor;
    private Vector2 startPos,endPos,direction;
    private bool hasStart = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStart)
        {
            endPos = Input.mousePosition;
            if (Input.GetMouseButtonUp(0)) 
            {
                direction = startPos - endPos;
                hasStart = false;
                rb.AddForce(-direction*forcePower * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cursor"))
        {
            startPos = Input.mousePosition;
           hasStart = true;
        }
    }

    private void Launch()
    {

    }
}
