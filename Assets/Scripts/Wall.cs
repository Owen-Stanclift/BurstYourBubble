using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator playerAnim = collision.GetComponent<Animator>();
            if (collision.gameObject.GetComponent<BubbleList>().getFirstBubble() != null)
            {
                Debug.Log("Switching to First Bubble");
                GameObject bubble = collision.gameObject.GetComponent<BubbleList>().getFirstBubble();
                Animator anim = bubble.GetComponent<Animator>();
                Vector3 pos = collision.transform.position;
                collision.transform.position = bubble.transform.position;
                anim.SetBool("IsDead", true);
                Destroy(bubble,0.5f);
            }
            else
            {
                Debug.Log("Only player left, player destroyed");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                playerAnim.SetBool("IsDead", true);
                Destroy(collision.gameObject,0.5f);
            }
        }
        if (collision.CompareTag("Bubble"))
        {
            Animator bubbleAnim = collision.GetComponent<Animator>();
            bubbleAnim.SetBool("IsDead", true);
            Destroy(collision.gameObject,0.5f);
        }
    }
}
