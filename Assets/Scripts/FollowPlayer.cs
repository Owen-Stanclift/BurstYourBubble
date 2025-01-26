using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    public bool followPlayer = false;

    [SerializeField]
    private float followSpeed = 5.0f;

    private float minDistance = 0.4f; //min distance from player

    void Update()
    {
        if(followPlayer && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position); 

            if(distance > minDistance)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                transform.position += direction * followSpeed * Time.deltaTime;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bubble"))
        //{
            if (!followPlayer && collision.CompareTag("Player"))
            {
                player = collision.gameObject;
                collision.gameObject.GetComponent<BubbleList>().AddBubble(gameObject);
                followPlayer = true;
                //Debug.Log("Following: " + collision.gameObject.transform.position);
            }
        //}
    }
}
