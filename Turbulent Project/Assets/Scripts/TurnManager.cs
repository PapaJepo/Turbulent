using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ResultText;
    [SerializeField]
    private TMP_Text TurnText;
    [SerializeField]
    private GameObject AttackButtonObject;

    public EventManager EventManager;
    public List<GameObject> CharacterList;
    public int RollAmount = 8;
    private int CurrentCharacter;
    private bool AttackCheck, RepairCheck, RunCheck;
    private bool Result;
    private bool Roll;
    // Start is called before the first frame update
    void Start()
    {
        RollAmount += 1;
        CurrentCharacter = 0;
        TurnText.text = "Player " + (CurrentCharacter + 1) + "'s turn";
        if(EventManager.GetComponent<EventManager>().EnemyActive == true)
        {
            AttackButtonObject.SetActive(true);
        }
        else
        {
            AttackButtonObject.SetActive(false);
        }

       
        //EventManager.GetComponent<EventManager>().
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AttackButton()
    {
        AttackCheck = true;
        RepairCheck = false;
        RunCheck = false;
    }

    public void RepairButton()
    {
        AttackCheck = false;
        RepairCheck = true;
        RunCheck = false;
    }

    public void RunButton()
    {
        AttackCheck = false;
        RepairCheck = false;
        RunCheck = true;
    }


    public void EndTurn()
    {
        if (CharacterList.Count != 0)
        {
            // ResultText.text = "Player " + CurrentCharacter;
            if(EventManager.GetComponent<EventManager>().EnemyActive == true)
            {
                if (AttackCheck == true)
                {
                    Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Attack, EventManager.GetComponent<EventManager>().AttackChance);
                    if (Roll == true)
                    {
                        ResultText.text = "Attack Hit!";
                    }
                    else if (Roll == false)
                    {
                        ResultText.text = "Attack Miss! You Lose HP";
                        CharacterList[CurrentCharacter].GetComponent<Character>().Health -= 1;

                    }
                }
                else if (RepairCheck == true)
                {
                    //CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;

                    Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Repair, EventManager.GetComponent<EventManager>().RepairChance);
                    if (Roll == true)
                    {
                        ResultText.text = "You Repair action worked!";
                        //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
                    }
                    else if (Roll == false)
                    {
                        ResultText.text = "You Repair action failed!";
                        // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
                    }
                }
                else if (RunCheck == true)
                {
                    // CharacterList[CurrentCharacter].GetComponent<Character>().Health -= 1;
                    Roll = ActionRoll(4, EventManager.GetComponent<EventManager>().RunChance);
                    if (Roll == true)
                    {
                        ResultText.text = "You Run Away!";
                        CharacterList.Remove(CharacterList[CurrentCharacter]);
                    }
                    else if (Roll == false)
                    {
                        ResultText.text = "You Can't Escape!";
                    }
                }
                else
                {
                    ResultText.text = "Turn Skipped";
                }

                AttackCheck = false;
                RepairCheck = false;
                RunCheck = false;

                CurrentCharacter = (CurrentCharacter + 1) % CharacterList.Count;
                TurnText.text = "Player " + (CurrentCharacter + 1) + "'s turn";
                if (CharacterList.Count == 0)
                {
                    TurnText.text = "No Players Left";

                }
            }
            else if(EventManager.GetComponent<EventManager>().EnemyActive == false)
            {

                if (RepairCheck == true)
                {
                    //CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;

                    Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Repair, EventManager.GetComponent<EventManager>().RepairChance);
                    if (Roll == true)
                    {
                        ResultText.text = "You Repair action worked!";
                        //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
                    }
                    else if (Roll == false)
                    {
                        ResultText.text = "You Repair action failed!";
                        // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
                    }
                }
                else if (RunCheck == true)
                {
                    // CharacterList[CurrentCharacter].GetComponent<Character>().Health -= 1;
                    Roll = ActionRoll(4, EventManager.GetComponent<EventManager>().RunChance);
                    if (Roll == true)
                    {
                        ResultText.text = "You Run Away!";
                        CharacterList.Remove(CharacterList[CurrentCharacter]);
                    }
                    else if (Roll == false)
                    {
                        ResultText.text = "You Can't Escape!";
                    }
                }
                else
                {
                    ResultText.text = "Turn Skipped";
                }

                AttackCheck = false;
                RepairCheck = false;
                RunCheck = false;

                CurrentCharacter = (CurrentCharacter + 1) % CharacterList.Count;
                TurnText.text = "Player " + (CurrentCharacter + 1) + "'s turn";
                if (CharacterList.Count == 0)
                {
                    TurnText.text = "No Players Left";

                }
            }
           
        }
        else
        {
            TurnText.text = "No Players Left";
        }
    }


    public bool ActionRoll(int number,int PlayerStat)
    {
        int Chance;
        Chance = number + Random.Range(1, RollAmount);
        Debug.Log(Chance);
        if(Chance > PlayerStat)
        {
            Result = true;
            
        }
        else if(Chance < PlayerStat)
        {
            Result = false;
           
        }
        return Result;
    }
}
