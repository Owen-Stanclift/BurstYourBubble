using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bubble"))
        {
            if(other.CompareTag("Player"))
            {
                if(other.gameObject.GetComponent<BubbleList>().getFirstBubble() != null)
                {
                    GameObject bubble = other.gameObject.GetComponent<BubbleList>().getFirstBubble();
                    other.transform.position = bubble.transform.position;
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
            else
            Destroy(other.gameObject);
        }
    }
}
