using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ResultText;
    [SerializeField]
    private TMP_Text TurnText;

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
       // ResultText.text = "Player " + CurrentCharacter;

        if(AttackCheck == true)
        {
            Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Attack);
            if(Roll == true)
            {
                ResultText.text = "Attack Hit!";
            }
            else if(Roll == false)
            {
                ResultText.text = "Attack Miss! You Lose HP";
                CharacterList[CurrentCharacter].GetComponent<Character>().Health -= 1;
            }
        }
        else if(RepairCheck == true)
        {
            //CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;

            Roll = ActionRoll(CharacterList[CurrentCharacter].GetComponent<Character>().Repair);
            if(Roll == true)
            {
                ResultText.text = "You Repair action worked!";
                //CharacterList[CurrentCharacter].GetComponent<Character>().Repair += 1;
            }
            else if(Roll == false)
            {
                ResultText.text = "You Repair action failed!";
                // CharacterList[CurrentCharacter].GetComponent<Character>().Repair -= 1;
            }
        }
        else if(RunCheck == true)
        {
           // CharacterList[CurrentCharacter].GetComponent<Character>().Health -= 1;
            Roll = ActionRoll(4);
            if(Roll == true)
            {
                ResultText.text = "You Run Away!";
            }
            else if(Roll == false)
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
    }


    public bool ActionRoll(int number)
    {
        int Chance;
        Chance = number + Random.Range(1, RollAmount);
        Debug.Log(Chance);
        if(Chance > 7)
        {
            Result = true;
            
        }
        else if(Chance < 7)
        {
            Result = false;
           
        }
        return Result;
    }
}
