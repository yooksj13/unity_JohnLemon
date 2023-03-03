using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text[] ClockText;
    public Text BestScore;
    public Text[] BestTime;
    public float time;
    public static float timeRecord;
    public static bool TimerOn;

    float bestTime;
    int bestScore;
    
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        if(PlayerPrefs.HasKey("BestScore")){
            bestScore = PlayerPrefs.GetInt("BestScore");
            bestTime = PlayerPrefs.GetFloat("BestTime");
        }
        else{
            bestScore = 0;
            bestTime = 0;
        }

        BestScore.text = (bestScore).ToString();
        BestTime[0].text = (((int)bestTime / 60 % 60)).ToString();
        BestTime[1].text = (((int)bestTime % 60)).ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            time += Time.deltaTime;
            timeRecord = time;
        }
        ClockText[0].text = (((int)time / 60 % 60)).ToString();
        ClockText[1].text = ((int)time % 60).ToString("D2");

        
        
    }

}
