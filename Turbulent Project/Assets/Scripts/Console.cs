using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class Console : MonoBehaviour
{
    public TextFeed textFeed;
    public bool consoleOn;
    public GameObject consoleWindow;

    private void Start()
    {
        consoleOn = false;
        consoleWindow.SetActive(false);
    }

    public void TriggerConsoleLog()
    {
        if (consoleOn == false)
        {
            consoleWindow.SetActive(true);
        }
        FindObjectOfType<ConsoleTextManager>().StartLog(textFeed);
    }
}
