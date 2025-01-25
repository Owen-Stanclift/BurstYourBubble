using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    public string tagName;
    public static bool trigger;

    private void Start()
    {
        trigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            Debug.Log("Hit");
            trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            Debug.Log("Leave");
            trigger = false;
        }
    }
    public bool isTrigger()
    {
        return trigger;
    }
}
