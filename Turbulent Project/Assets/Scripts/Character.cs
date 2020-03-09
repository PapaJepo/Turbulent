using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    [SerializeField]
    private TMP_Text UIText;
    public int Health = 5;
    public int Attack = 5;
    public int Repair = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = "Health:" + Health + "\nAttack:" + Attack + "\nRepair:" + Repair;
    }
}
