using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
    public TextFeed textFeed;
    public bool consoleOn;
    public GameObject consoleWindow;

    public TMP_Text openCloseButton;

    [SerializeField] private ObjectClick clickScript;

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
            FindObjectOfType<ConsoleTextManager>().StartLog(textFeed);
            consoleOn = true;
            openCloseButton.text = "Close Mission Log";
        }
        else if (consoleOn == true)
        {
            consoleOn = false;
            consoleWindow.SetActive(false);
            openCloseButton.text = "Open Mission Log";
            clickScript.changePosition = false;
        }
        
    }
}
