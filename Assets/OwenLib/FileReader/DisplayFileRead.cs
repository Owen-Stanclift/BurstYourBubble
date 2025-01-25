using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFileRead : MonoBehaviour
{

    public TMP_Text textBox;
    public GetText textFile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textFile.DisplayName(textBox);
    }
}
