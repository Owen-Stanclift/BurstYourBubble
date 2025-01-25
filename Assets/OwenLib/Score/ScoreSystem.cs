using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public string screenText;
    public bool reset;
    [SerializeField]
    private FloatSO scoreSO;
    [SerializeField]
    private FloatSO highScoreSO;
    // Start is called before the first frame update
    void Start()
    {
        if (reset)
        scoreSO.MyValue =  0;
    }
    public void ResetScore()
    {
        scoreSO.MyValue = 0;
        highScoreSO.MyValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore(TMP_Text scoretext)
    {
        scoretext.text = screenText + scoreSO.MyValue;
    }
    public void DisplayHighScore(TMP_Text scoretext)
    {
        scoretext.text = screenText + highScoreSO.MyValue;
    }
    public float GetScore()
    {
        return scoreSO.MyValue;
    }
    public void SetScore(float num)
    {
        scoreSO.MyValue = num;
        if(scoreSO.MyValue > highScoreSO.MyValue)
        highScoreSO.MyValue = scoreSO.MyValue;
    }
}
