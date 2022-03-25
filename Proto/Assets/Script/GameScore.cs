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

    [SerializeField] public int Score;
    
    void Awake()
    {
        activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "Easy") 
        {
            timeR = 30;
        }
        else if (activeScene == "Medium")
        {
            timeR = 60;
        }
    }

    void Update()
    {
        R.text = "Remaining "+ Math.Floor(timeR); 

        if(Score == 6) 
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
