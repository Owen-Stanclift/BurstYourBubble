using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class PointDisplay : MonoBehaviour
{
    public GameObject textBox;
    public GameObject canvas;
    public float speed;
    public static Vector3 spawnPos;
    public static int points;
    public float fadeDuration;
    public static bool isAdd;
    private bool isMove;
    private float time;
    private TMP_Text text;
    private GameObject newTextBox;
    public static bool isGenerate;
    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        points = 0;
        isAdd = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGenerate)
        {
            if(newTextBox != null)
            {
                Destroy(newTextBox);
            }
            newTextBox = textBox;
            isGenerate = false;
            text = newTextBox.GetComponent<TMP_Text>();
            time = 0;
            isMove = false;
            if (isAdd)
            {
                text.text = "+" + points;
            }
            else
            {
                text.text = "-" + points;
            }
            isMove = true;
            newTextBox = Instantiate(newTextBox, spawnPos, textBox.transform.rotation,canvas.transform);
            newTextBox.SetActive(true);
        }
        if (isMove && newTextBox != null)
        {
            text = newTextBox.GetComponent<TMP_Text>();
            newTextBox.transform.position = Vector3.MoveTowards(newTextBox.transform.position,new Vector3(newTextBox.transform.position.x,CameraSystem.height, newTextBox.transform.position.z), Time.deltaTime * speed);
            Color newColor = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1, 0, time / fadeDuration));
            time += Time.deltaTime;
            text.color = newColor;
            if(text.color.a <= 0)
            {
                Destroy(newTextBox.gameObject);
            }
        }
    }

}
