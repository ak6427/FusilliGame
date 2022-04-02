using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameScore : MonoBehaviour
{
    public float timeR;
    public TMP_Text R; // PIIRRÄ JÄLJELLÄ OLEVA AIKA RUUDULLE
    private string activeScene;
    public int Score;
    private int maxScore;
    
    void Awake()
    {
        activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "Easy") 
        {
            timeR = 30;
            maxScore = 6;
        }
        else if (activeScene == "Medium")
        {
            timeR = 90;
            maxScore = 28;
        }
    }

    void Update()
    {
        R.text = "Remaining "+ Math.Floor(timeR); 

        if(Score == maxScore) 
        {
            SceneManager.LoadScene("Victory");
        }    
        
        // TIMERIN PÄIVITYS
        if(timeR > 0)
        {
            timeR -= Time.deltaTime;
        }

        else if(timeR <= 0) 
        {
            SceneManager.LoadScene("Failure");
        }
    }
}
