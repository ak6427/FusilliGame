using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameScore : MonoBehaviour
{
    [SerializeField]
    public float timeR = 300;

    public TMP_Text R; // PIIRRÄ JÄLJELLÄ OLEVA AIKA RUUDULLE

    [SerializeField] public int Score;
    
    void Update()
    {
        R.text = "Remaining "+ Math.Floor(timeR); 

        if(Score == 6){
            SceneManager.LoadScene("Victory");
        }    
        
        // TIMERIN PÄIVITYS
        if(timeR > 0){
            timeR -= Time.deltaTime;
        }
        else if(timeR <= 0){
         SceneManager.LoadScene("Failure");
        }
    }
}
