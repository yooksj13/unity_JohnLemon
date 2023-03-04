using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup; 
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public CanvasGroup gameoverBackgroundImageCanvasGroup;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    float curTime;
    int curScore;
    float bestTime;
    int bestScore;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            curScore = Coin.money;
            curTime = Timer.timeRecord;
            Rank(curScore, curTime);
            EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        Timer.TimerOn = false;
        Coin.money = 0;

        if(!m_HasAudioPlayed)
        {
            audioSource.Play ();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            { 
                HPManager.hp-=1;

                if(HPManager.hp > 0){
                    SceneManager.LoadScene (0);
                }
                else{
                    gameoverBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
                }
            }
            else
            {
                Application.Quit ();
            }
        }
    
    }

    void Rank(int currentScore, float currentTime){
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);
        PlayerPrefs.SetFloat("CurrentPlayerTime", currentTime);

        if(!PlayerPrefs.HasKey("BestScore")){
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.SetFloat("BestTime", currentTime);
        }
        else{
            bestScore = PlayerPrefs.GetInt("BestScore");
            bestTime = PlayerPrefs.GetFloat("BestTime");

            if(bestScore < currentScore){
                PlayerPrefs.SetInt("BestScore", currentScore);
                PlayerPrefs.SetFloat("BestTime", currentTime);
            }
            else if(bestScore == currentScore){
                if(bestTime > currentTime){
                    PlayerPrefs.SetInt("BestScore", currentScore);
                    PlayerPrefs.SetFloat("BestTime", currentTime);
                }
            }
        }
    }

    public void OnclickRestart(){
        HPManager.hp=4;
        SceneManager.LoadScene (0);
    }

    public void OnClickExit()
    {
        Application.Quit ();
    }
    
}