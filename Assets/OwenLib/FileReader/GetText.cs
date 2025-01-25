using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;
public class GetText : MonoBehaviour
{
    public string folderName;
    public string fileName;
    public static List<string> text;
    // Start is called before the first frame update
    public void readText()
    {
        string readFile = Application.streamingAssetsPath + "/" + folderName + "/" + fileName + ".txt";
        text = File.ReadAllLines(readFile).ToList();
        if(readFile != null)
        {
            Debug.Log("File read");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayName(TMP_Text textBox)
    {
        textBox.text = fileName;
    }
}
