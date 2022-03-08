using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameScore : MonoBehaviour
{
    public float timeR = 300;
    public TMP_Text R;
    [SerializeField] public int Score;
    
    void Update()
    {
        R.text = "Remaining "+ Math.Floor(timeR);   
        if(Score == 6){
            SceneManager.LoadScene("Victory");
        }    
        
        if(timeR > 0){
            timeR -= Time.deltaTime;
        }
        else if(timeR <= 0){
         SceneManager.LoadScene("Failure");
        }
    }
}
