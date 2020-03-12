using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    public TMP_Text StartEvent;
    [Header("Event Text")]
    [Multiline]
    public List<string> EventText;

    [SerializeField]
    private TMP_Text UpdateEvent;
    public int RandomEvent;
    
    [Header("Roll Chances")]
    [Tooltip("Chances for actions suceeding")]
    public int AttackChance;
    [Tooltip("Chances for actions suceeding")]
    public int RepairChance;
    [Tooltip("Chances for actions suceeding")]
    public int RunChance;

    public GameObject TurnManager;
    public bool EnemyActive;
    public bool Repaired;
    public bool Repaired1;
    public bool Restart;
    [SerializeField]
    private TMP_Text ButtonText1;
    [SerializeField]
    private TMP_Text ButtonText2;
    [SerializeField]
    private TMP_Text ButtonText3;
    [SerializeField]
    private TMP_Text ButtonText4;


    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject Scene3;
    public GameObject Scene4;
    public RenderTexture Scene1Tex;
    public RenderTexture Scene2Tex;
    public RenderTexture Scene3Tex;
    public RenderTexture Scene4Tex;

    public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        RandomEvent = Random.Range(0, EventText.Count);

        //StartEvent.text = EventText[RandomEvent];
        switch (RandomEvent)
        {
            case 0:
                AttackChance = 12;
                RepairChance = 6;
                RunChance = 3;
                EnemyActive = false;
                break;
            case 1:
                AttackChance = 8;
                RepairChance = 7;
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
       if(RandomEvent == 0 )
        {
            ButtonText1.text = "Perform Action";
            ButtonText2.text = "Move to Engine";
            ButtonText3.text = "Move to Control Panel";
            ButtonText4.text = "Move to Unknown Substance";

            if (Repaired == false)
            {
                UpdateEvent.text = " " + (10 - TurnManager.GetComponent<TurnManager>().Turn) + " Turns left Until the engine fails";

            }
            else if(Repaired == true)
            {
                UpdateEvent.text = "Engine was repaired";
            }
        }
       else if(RandomEvent == 1)
        {
            ButtonText1.text = "Perform Action";
            ButtonText2.text = "Move to MedBay Panel";
            ButtonText3.text = "Move to Life Support";
            ButtonText4.text = "Move to Unknown Substance";


            if (Repaired1 == false)
            {
                UpdateEvent.text = " " + (10 - TurnManager.GetComponent<TurnManager>().Turn) + " Turns left Until the MedBay shuts down";

            }
            else if (Repaired1 == true)
            {
                UpdateEvent.text = "Medbay was repaired";
            }
        }

       if(Repaired == true && Repaired1== true && Restart == true)
        {
            EndScreen.SetActive(true);
        }
    }

    public void ChangeCameras()
    {
        TurnManager.GetComponent<TurnManager>().CurrentCharacter = 1;

        RandomEvent = 1;
        TurnManager.GetComponent<TurnManager>().TurnText.text = "Player " + (TurnManager.GetComponent<TurnManager>().CurrentCharacter + 1) + "'s turn";
        
        Scene1.GetComponent<Renderer>().material.mainTexture = Scene1Tex;
        Scene2.GetComponent<Renderer>().material.mainTexture = Scene2Tex;
        Scene3.GetComponent<Renderer>().material.mainTexture = Scene3Tex;
        Scene4.GetComponent<Renderer>().material.mainTexture = Scene4Tex;

    }
    public void ChangeCameras2()
    {

        TurnManager.GetComponent<TurnManager>().CurrentCharacter = 0;
        RandomEvent = 0;
        TurnManager.GetComponent<TurnManager>().TurnText.text = "Player " + (TurnManager.GetComponent<TurnManager>().CurrentCharacter + 1) + "'s turn";
        Scene1.GetComponent<Renderer>().material.mainTexture = Scene2Tex;
        Scene2.GetComponent<Renderer>().material.mainTexture = Scene1Tex;
        Scene3.GetComponent<Renderer>().material.mainTexture = Scene3Tex;
        Scene4.GetComponent<Renderer>().material.mainTexture = Scene4Tex;


    }
    public void ChangeCameras3()
    {

        Scene1.GetComponent<Renderer>().material.mainTexture = Scene3Tex;
        Scene2.GetComponent<Renderer>().material.mainTexture = Scene1Tex;
        Scene3.GetComponent<Renderer>().material.mainTexture = Scene2Tex;
        Scene4.GetComponent<Renderer>().material.mainTexture = Scene4Tex;


    }
    public void ChangeCameras4()
    {

        Scene1.GetComponent<Renderer>().material.mainTexture = Scene4Tex;
        Scene2.GetComponent<Renderer>().material.mainTexture = Scene1Tex;
        Scene3.GetComponent<Renderer>().material.mainTexture = Scene2Tex;
        Scene4.GetComponent<Renderer>().material.mainTexture = Scene3Tex;


    }

}
