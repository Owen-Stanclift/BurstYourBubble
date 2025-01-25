using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public bool showSettings;
    public Toggle[] toggles;
    public static bool[] conditions;
    public static bool isMade = false;
    // Start is called before the first frame update
    void Start()
    {
        if (toggles.Length != 0)
        {
            if (!isMade)
            {
                conditions = new bool[toggles.Length];
                for (int i = 0; i < toggles.Length; i++)
                {
                    conditions[i] = toggles[i].isOn;
                }
                isMade = true;
            }
            else
            {
                setToggles();
            }
        }
        settingsMenu.SetActive(showSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleSettings()
    {
        showSettings = !showSettings;
        if (showSettings)
        {
            if(toggles.Length != 0)
            setToggles();
        }
        settingsMenu.SetActive(showSettings);
    }
    public void setToggles()
    {
        if (toggles.Length != 0)
        {
            for (int i = 0; i < conditions.Length; i++)
            {
                toggles[i].isOn = conditions[i];
            }
        }
    }
    public void changeToggle()
    {
        if (toggles.Length != 0)
        {
            for (int i = 0; i < conditions.Length; i++)
            {
                conditions[i] = toggles[i].isOn;
            }
        }
    }
}
