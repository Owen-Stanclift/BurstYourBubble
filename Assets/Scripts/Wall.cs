using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<BubbleList>().getFirstBubble() != null)
            {
                Debug.Log("Switching to First Bubble");
                GameObject bubble = collision.gameObject.GetComponent<BubbleList>().getFirstBubble();
                Vector3 pos = collision.transform.position;
                collision.transform.position = bubble.transform.position;
                Destroy(bubble);
            }
            else
            {
                Debug.Log("Only player left, player destroyed");
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Bubble"))
        {
            Destroy(collision.gameObject);
        }
    }
}
