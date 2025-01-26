using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Animator playerAnim = collision.GetComponent<Animator>();
                if (collision.gameObject.GetComponent<BubbleList>().getFirstBubble() != null)
                {
                    GameObject bubble = collision.gameObject.GetComponent<BubbleList>().getFirstBubble();
                    Animator anim = bubble.GetComponent<Animator>();
                    Vector3 pos = collision.transform.position;
                    collision.transform.position = bubble.transform.position;
                    anim.SetBool("IsDead", true);
                    Destroy(bubble,0.6f);
                }
                else
                {
                playerAnim.SetBool("IsDead", true);
                Destroy(collision.gameObject,0.6f);
                }
        }
        if (collision.CompareTag("Bubble"))
        {
            Animator bubbleAnim = collision.GetComponent<Animator>();
            bubbleAnim.SetBool("IsDead", true);
            Destroy(collision.gameObject,0.6f);
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
