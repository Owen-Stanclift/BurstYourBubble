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
    public void RemoveBubble()
    {
        Destroy(bubbleList[bubbleList.Count-1],0.5f);
    }

    public GameObject getFirstBubble()
    {
        if (bubbleList.Count > 0)
        {
            return bubbleList[bubbleList.Count-1];
        }
        else
        {
            return null;
        }

    }
}
