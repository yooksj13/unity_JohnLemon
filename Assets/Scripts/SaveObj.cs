using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObj : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        //score = 1;
        //Debug.Log("score : " + score);
        int SaveData = PlayerPrefs.GetInt("Save");
        Debug.Log(SaveData);
        PlayerPrefs.SetInt("Save", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
