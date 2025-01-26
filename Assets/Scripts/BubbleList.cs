using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleList : MonoBehaviour
{
    List<GameObject> bubbleList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBubble(GameObject bubble)
    {
        bubbleList.Add(bubble);
    }

    public GameObject getFirstBubble()
    {
        if (bubbleList[0] != null)
        {
            return bubbleList[0];
        }
        else
            return null;

    }
}
