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


    public bool EnemyActive;
    // Start is called before the first frame update
    void Start()
    {
        RandomEvent = Random.Range(0, EventText.Count);

        StartEvent.text = EventText[RandomEvent];
        switch (RandomEvent)
        {
            case 0:
                AttackChance = 12;
                RepairChance = 2;
                RunChance = 3;
                EnemyActive = true;
                break;
            case 1:
                AttackChance = 8;
                RepairChance = 5;
                RunChance = 6;
                EnemyActive = true;
                break;
            case 2:
                AttackChance = 7;
                RepairChance = 8;
                RunChance = 9;
                EnemyActive = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
