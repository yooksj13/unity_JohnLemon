using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text[] ClockText;
    float time;
    public static bool TimerOn;
    
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            time += Time.deltaTime;
        }
        ClockText[0].text = (((int)time / 60 % 60)).ToString();
        ClockText[1].text = ((int)time % 60).ToString("D2");
        
    }

}
