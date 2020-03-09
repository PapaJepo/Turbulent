using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleTextManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text consoleText;
    
    private Queue<string> consoleLog;
    
    void Start()
    {
        consoleLog = new Queue<string>();
    }

    public void StartLog(TextFeed textFeed)
    {
        nameText.text = textFeed.name;
        
        consoleLog.Clear();

        foreach (string consoleTextFeed in textFeed.consoleTextFeed)
        {
            consoleLog.Enqueue(consoleTextFeed);
        }

        DisplayNextLog();
    }

    public void DisplayNextLog()
    {
        if (consoleLog.Count == 0)
        {
            StopAllCoroutines();
            EndLog();
            return;
        }

        string consoleTextFeed = consoleLog.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeToConsole(consoleTextFeed));
    }

    IEnumerator TypeToConsole(string consoleTextFeed)
    {
        consoleText.text = "";
        foreach (char letter in consoleTextFeed.ToCharArray())
        {
            consoleText.text += letter;
            yield return null;
        }
    }

    void EndLog()
    {
        consoleText.text = ("End of Current Logs. You have read all " +
                            "currently available mission logs and there " +
                            "is nothing new to report.");
    }

    void LogForceClose()
    {
        consoleLog.Clear();       
    }
}
