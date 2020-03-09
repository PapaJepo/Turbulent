using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    public TMP_Text StartEvent;
    [Header("Event Text")]
    public List<string> EventText;
    
    int RandomEvent;
    
    [Header("Roll Chances")]
    [Tooltip("Chances for actions suceeding")]
    public int AttackChance;
    [Tooltip("Chances for actions suceeding")]
    public int RepairChance;
    [Tooltip("Chances for actions suceeding")]
    public int RunChance;

    // Start is called before the first frame update
    void Start()
    {
        RandomEvent = Random.Range(0, EventText.Count);

        StartEvent.text = EventText[RandomEvent];
    }

    // Update is called once per frame
    void Update()
    {
        switch(RandomEvent)
        {
            case 0:
                AttackChance = 1;
                RepairChance = 2;
                RunChance = 3;
                break;
            case 1:
                AttackChance = 4;
                RepairChance = 5;
                RunChance = 6;
                break;
            case 2:
                AttackChance = 7;
                RepairChance = 8;
                RunChance = 9;
                break;
        }
    }
}
