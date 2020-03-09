using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    private TMP_Text UIText;
    public int Health = 5;
    public int Attack = 5;
    public int Repair = 5;


    public Image HealthStat;


    public Color HighHP;
    public Color MidHP;
    public Color LowHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = "Health:" + Health + "\nAttack:" + Attack + "\nRepair:" + Repair;

        switch(Health)
        {
            case 0:
                HealthStat.fillAmount = 0;
                break;
            case 1:
                HealthStat.fillAmount = 0.2f;
                HealthStat.color = LowHP;
                break;
            case 2:
                HealthStat.fillAmount = 0.4f;
                HealthStat.color = MidHP;
                break;
            case 3:
                HealthStat.fillAmount = 0.6f;
                HealthStat.color = MidHP;
                break;
            case 4:
                HealthStat.fillAmount = 0.8f;
                HealthStat.color = HighHP;
                break;
            case 5:
                HealthStat.fillAmount = 1;
                HealthStat.color = HighHP;
                break;

        }
    }
}
