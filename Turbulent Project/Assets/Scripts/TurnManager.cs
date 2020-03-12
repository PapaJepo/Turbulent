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
    public TMP_Text TurnText;
    [SerializeField]
    private GameObject AttackButtonObject;
    [SerializeField]
    private TMP_Text ActionText;
    [SerializeField]
    private TMP_Text TurnCounter;

    public GameObject Creature;

    public List<GameObject> CharacterUI;
    public List<GameObject> CharacterRef;
    public int Turn = 1;
    public EventManager EventManager;
    public List<GameObject> CharacterList;
    public int RollAmount = 8;


    public int CurrentCharacter;
    private bool AttackCheck, RepairCheck, RunCheck, Move1Check, Move2Check, Move3Check;
    private bool Close1, Close2, Close3;
    private bool UseCheck;
    private bool Result;
    private bool Roll;

    // Start is called before the first frame update
    void Start()
    {
        TurnCounter.text = "Turn " + Turn;
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

        CharacterUI[CurrentCharacter].SetActive(true);
        //EventManager.GetComponent<EventManager>().
    }

    // Update is called once per frame
    void Update()
    {
        if ((CharacterList[1].GetComponent<Character>().Health <= 0))
        {
            ResultText.text = "Game Over";
        }
    }

    public void AttackButton()
    {
        AttackCheck = true;
        RepairCheck = false;
        RunCheck = false;
        Move1Check = false;
        Move2Check = false;
        Move3Check = false;
        UseCheck = false;
    }

    public void RepairButton()
    {
        AttackCheck = false;
        RepairCheck = true;
        RunCheck = false;

        Move1Check = false;
        Move2Check = false;
        Move3Check = false;
        UseCheck = false;
    }

    public void RunButton()
    {
        AttackCheck = false;
        RepairCheck = false;
        RunCheck = true;

        Move1Check = false;
        Move2Check = false;
        Move3Check = false;
        UseCheck = false;
    }

    public void Move1()
    {
        AttackCheck = false;
        RepairCheck = false;
        RunCheck = false;

        Move1Check = true;
        Move2Check = false;
        Move3Check = false;
        UseCheck = false;
    }
    public void Move2()
    {
        AttackCheck = false;
        RepairCheck = false;
        RunCheck = false;

        Move1Check = false;
        Move2Check = true;
        Move3Check = false;
        UseCheck = false;
    }
    public void Move3()
    {
        AttackCheck = false;
        RepairCheck = false;
        RunCheck = false;

        Move1Check = false;
        Move2Check = false;
        Move3Check = true;
        UseCheck = false;
    }
    public void UseButton()
    {
        AttackCheck = false;
        RepairCheck = false;
        RunCheck = false;

        Move1Check = false;
        Move2Check = false;
        Move3Check = false;
        UseCheck = true;
    }



    public void EndTurn()
    {
        if (CharacterList.Count != 0)
        {
            if (CharacterList[CurrentCharacter].GetComponent<Character>().Health > 0)
            {


                CharacterUI[CurrentCharacter].SetActive(false);
                // ResultText.text = "Player " + CurrentCharacter;


                //Enemy Present


                if (EventManager.GetComponent<EventManager>().EnemyActive == true)
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
                            switch (EventManager.GetComponent<EventManager>().RandomEvent)
                            {
                                case 0:
                                    EventManager.GetComponent<EventManager>().Repaired = true;
                                    break;
                                case 1:
                                    EventManager.GetComponent<EventManager>().Repaired1 = true;
                                    break;
                            }
                            //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
                        }
                        else if (Roll == false)
                        {
                            ResultText.text = "You Repair action failed!";
                            // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
                        }
                    }
                    if (UseCheck == true)
                    {
                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                        {
                            case 0:
                                if (Close2 == true)
                                {
                                    if (EventManager.GetComponent<EventManager>().Repaired == false)
                                    {
                                        ResultText.text = "The engine must be repaired before it is restarted";
                                    }
                                    else if (EventManager.GetComponent<EventManager>().Repaired == true)
                                    {
                                        ResultText.text = "You successfully restart the engine";
                                        Creature.SetActive(true);
                                    }
                                }
                                else if (Close1 == true)
                                {

                                    Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Repair, EventManager.GetComponent<EventManager>().RepairChance);
                                    if (Roll == true)
                                    {
                                        ResultText.text = "You Repair action worked!";

                                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                                        {
                                            case 0:
                                                EventManager.GetComponent<EventManager>().Repaired = true;
                                                break;
                                            case 1:
                                                EventManager.GetComponent<EventManager>().Repaired1 = true;
                                                break;
                                        }
                                        //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
                                    }
                                    else if (Roll == false)
                                    {
                                        ResultText.text = "You Repair action failed!";
                                        // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
                                    }
                                }
                                else if (Close3 == true)
                                {
                                    ResultText.text = "You have no idea where this unknown substance came from but it looks like it came from the vents";
                                }
                                else
                                {
                                    ResultText.text = "There's nothing you can interact with";
                                }
                                break;
                            case 1:
                                if (Close2 == true)
                                {
                                    /* if (EventManager.GetComponent<EventManager>().Repaired == false)
                                     {
                                         ResultText.text = "The engine must be repaired before it is restarted";
                                     }
                                     else if (EventManager.GetComponent<EventManager>().Repaired == true)
                                     {
                                         ResultText.text = "You successfully restart the engine";
                                         Creature.SetActive(true);
                                     }*/
                                    ResultText.text = "The life support is below average levels but should be fine to reach port, it's detecting abnormal gas readings in the lower levels";
                                }
                                else if (Close1 == true)
                                {

                                    Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Repair, EventManager.GetComponent<EventManager>().RepairChance);
                                    if (Roll == true)
                                    {
                                        ResultText.text = "You Repair action worked!";

                                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                                        {
                                            case 0:
                                                EventManager.GetComponent<EventManager>().Repaired = true;
                                                break;
                                        }
                                        //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
                                    }
                                    else if (Roll == false)
                                    {
                                        ResultText.text = "You Repair action failed!";
                                        // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
                                    }
                                }
                                else if (Close3 == true)
                                {
                                    ResultText.text = "You have no idea where this unknown substance came from but it looks like it came from the vents";
                                }
                                else
                                {
                                    ResultText.text = "There's nothing you can interact with";
                                }
                                break;
                        }

                    }
                    else if (RunCheck == true)
                    {
                        //ResultText.text = "You return to the control room";
                        /*
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
                        */
                    }
                    else if (Move1Check == true)
                    {
                        CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 1;
                        ResultText.text = "You move to the engine";
                        Close1 = true;
                        Close2 = false;
                        Close3 = false;
                    }
                    else if (Move2Check == true)
                    {
                        CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 2;
                        ResultText.text = "You move to the control panel";
                        Close1 = false;
                        Close2 = true;
                        Close3 = false;
                    }
                    else if (Move3Check == true)
                    {
                        CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 3;
                        ResultText.text = "You move to the unknown substance";
                        Close1 = false;
                        Close2 = false;
                        Close3 = true;
                    }
                    else
                    {
                        ResultText.text = "Turn Skipped";
                    }

                    AttackCheck = false;
                    RepairCheck = false;
                    RunCheck = false;
                    Move1Check = false;
                    Move2Check = false;
                    Move3Check = false;
                    UseCheck = false;
                    //CurrentCharacter = (CurrentCharacter + 1) % CharacterList.Count;
                    TurnText.text = "Player " + (CurrentCharacter + 1) + "'s turn";


                    if (Turn % 2 == 0)
                    {

                        //if (CharacterList[0].GetComponent<Character>().Health == CharacterList[1].GetComponent<Character>().Health)
                        //{
                        //int AttackPlayer = Random.Range(0, 2);
                        if (CharacterList[1].GetComponent<Character>().Health > 0)
                        {
                            CharacterList[1].GetComponent<Character>().Health -= 1;
                            ActionText.text = "The creature attacks " + 1;

                        }
                        else if (CharacterList[1].GetComponent<Character>().Health == 0)
                        {
                            //ActionText.text = "The creature eats parts of player  " + 1;
                            ActionText.text = "Game Over";
                        }


                        //}


                    }
                    else
                    {
                        ActionText.text = "The creature eyes you up";
                    }


                    if (CharacterList.Count == 0)
                    {
                        TurnText.text = "No Players Left";

                    }
                }



                //No Enemy



                else if (EventManager.GetComponent<EventManager>().EnemyActive == false)
                {
                    ActionText.text = "";

                    if (UseCheck == true)
                    {

                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                        {
                            case 0:
                                if (Close2 == true)
                                {
                                    if (EventManager.GetComponent<EventManager>().Repaired == false)
                                    {
                                        ResultText.text = "The engine must be repaired before it is restarted";
                                    }
                                    else if (EventManager.GetComponent<EventManager>().Repaired == true)
                                    {
                                        ResultText.text = "You successfully restart the engine";
                                        Creature.SetActive(true);
                                    }
                                }
                                else if (Close1 == true)
                                {

                                    Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Repair, EventManager.GetComponent<EventManager>().RepairChance);
                                    if (Roll == true)
                                    {
                                        ResultText.text = "You Repair action worked!";

                                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                                        {
                                            case 0:
                                                EventManager.GetComponent<EventManager>().Repaired = true;
                                                break;
                                            case 1:
                                                EventManager.GetComponent<EventManager>().Repaired1 = true;
                                                break;
                                        }
                                        //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
                                    }
                                    else if (Roll == false)
                                    {
                                        ResultText.text = "You Repair action failed!";
                                        // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
                                    }
                                }
                                else if (Close3 == true)
                                {
                                    ResultText.text = "You have no idea where this unknown substance came from but it looks like it came from the vents";
                                }
                                else
                                {
                                    ResultText.text = "There's nothing you can interact with";
                                }
                                break;
                            case 1:
                                if (Close2 == true)
                                {
                                    /* if (EventManager.GetComponent<EventManager>().Repaired == false)
                                     {
                                         ResultText.text = "The engine must be repaired before it is restarted";
                                     }
                                     else if (EventManager.GetComponent<EventManager>().Repaired == true)
                                     {
                                         ResultText.text = "You successfully restart the engine";
                                         Creature.SetActive(true);
                                     }*/
                                    ResultText.text = "The life support is below average levels but should be fine to reach port, it's detecting abnormal gas readings in the lower levels";
                                }
                                else if (Close1 == true)
                                {

                                    Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Repair, EventManager.GetComponent<EventManager>().RepairChance);
                                    if (Roll == true)
                                    {
                                        ResultText.text = "You Repair action worked!";

                                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                                        {
                                            case 0:
                                                EventManager.GetComponent<EventManager>().Repaired = true;
                                                break;
                                            case 1:
                                                EventManager.GetComponent<EventManager>().Repaired1 = true;
                                                break;
                                        }
                                        //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
                                    }
                                    else if (Roll == false)
                                    {
                                        ResultText.text = "You Repair action failed!";
                                        // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
                                    }
                                }
                                else if (Close3 == true)
                                {
                                    ResultText.text = "You have no idea where this unknown substance came from but it looks like it came from the vents";
                                }
                                else
                                {
                                    ResultText.text = "There's nothing you can interact with";
                                }
                                break;
                        }


                    }
                    else if (RunCheck == true)
                    {
                        //ResultText.text = "You return to the control room";
                        /*
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
                        */
                    }
                    else if (Move1Check == true)
                    {
                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                        {
                            case 0:
                        CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 1;
                        ResultText.text = "You move to the engine";
                                break;
                            case 1:
                                CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 1;
                                ResultText.text = "You move to the engine";
                                break;
                    
                    }
                        Close1 = true;
                        Close2 = false;
                        Close3 = false;
                    }
                    else if (Move2Check == true)
                    {
                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                        {
                            case 0:
                        CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 2;
                        ResultText.text = "You move to the control panel";
                                break;
                            case 1:
                                CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 2;
                                ResultText.text = "You move to the Life Support Panel";
                                break;
                    }
                        Close1 = false;
                        Close2 = true;
                        Close3 = false;
                    }
                    else if (Move3Check == true)
                    {
                        switch (EventManager.GetComponent<EventManager>().RandomEvent)
                        {
                            case 0:
                                
                        CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 3;
                        ResultText.text = "You move to the unknown substance";
                                break;
                            case 1:
                                CharacterRef[CurrentCharacter].GetComponent<WaypointMove>().CurrentWaypoint = 3;
                                ResultText.text = "You move to the Unkown Substance";
                                break;
                       
                    }
                    Close1 = false;
                    Close2 = false;
                    Close3 = true;
                }
                    else
                    {
                        ResultText.text = "Turn Skipped";
                    }

                    AttackCheck = false;
                    RepairCheck = false;
                    RunCheck = false;
                    Move1Check = false;
                    Move2Check = false;
                    Move3Check = false;
                    UseCheck = false;

                    //CurrentCharacter = (CurrentCharacter + 1) % CharacterList.Count;
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
            Turn += 1;
            TurnCounter.text = "Turn " + Turn;
            CharacterUI[CurrentCharacter].SetActive(true);
        }
        else
        {
           ActionText.text = (" Character is dead");
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
