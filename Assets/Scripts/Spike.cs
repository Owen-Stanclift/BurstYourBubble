using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
                if (collision.gameObject.GetComponent<BubbleList>().getFirstBubble() != null)
                {
                    GameObject bubble = collision.gameObject.GetComponent<BubbleList>().getFirstBubble();
                Vector3 pos = collision.transform.position;
                    collision.transform.position = bubble.transform.position;
                    Destroy(bubble);
                }
                else
                {
                    Destroy(collision.gameObject,0.4f);
                }
        }
        if (collision.CompareTag("Bubble"))
        {
            Destroy(collision.gameObject,0.4f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
