using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text TimerText;

    public float Seconds, Minutes;
    
    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<Text>() as Text;
        
    }

    // Update is called once per frame
    void Update()
    {

        Minutes = (int) (Time.time / 60f);
        Seconds = (int) (Time.time % 60);
        TimerText.text = Minutes.ToString("16800") + " : " + Seconds.ToString("00");

    }
}
