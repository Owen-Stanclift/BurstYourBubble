using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text text;
    public bool highScore;
    [SerializeField]
    private ScoreSystem scoreSystem;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (highScore)
        scoreSystem.DisplayHighScore(text);
        else
        scoreSystem.DisplayScore(text);
    }
}
