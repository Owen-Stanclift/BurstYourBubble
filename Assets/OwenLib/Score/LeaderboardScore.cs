using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardScore : MonoBehaviour
{
    public ScoreSystem[] players;
    public float moveSpeed;
    private Vector3 pos1, pos2;
    private int index1, index2;
    private ScoreSystem temp;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            for (int i = 0; i < players.Length - 1; i++)
            {
                if (players[i].GetScore() > players[i + 1].GetScore())
                {
                    isMoving=true;
                    index1 = i;
                    index2 = i+1;
                    pos1 = players[i].gameObject.transform.position;
                    pos2 = players[i + 1].gameObject.transform.position;
                }
            }
        }
        else
        {
            players[index1].gameObject.transform.position = Vector3.MoveTowards(players[index1].gameObject.transform.position, pos2, Time.deltaTime * moveSpeed);
            players[index2].gameObject.transform.position = Vector3.MoveTowards(players[index2].gameObject.transform.position, pos1, Time.deltaTime * moveSpeed);
            if (players[index1].transform.position == pos2 && players[index2].transform.position == pos1)
            {
                temp = players[index1];
                players[index1] = players[index2];
                players[index2] = temp;
                isMoving=false;
            }
        }
    }
}
