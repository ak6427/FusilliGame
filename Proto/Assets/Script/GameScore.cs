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
    public string timeRemainingText = "Aikaa jäljellä: ";
    public SceneSaver sceneSaver;
    
    void Awake()
    {
        sceneSaver = FindObjectOfType<SceneSaver>();
        activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "Easy") 
        {
            timeR = 30;
            maxScore = 6;
        }
        else if (activeScene == "Medium")
        {
            timeR = 140;
            maxScore = 28;
        }
        else if (activeScene == "Hard")
        {
            timeR = 280;
            maxScore = 56;
        }
    }

    void Update()
    {
        //PlayerPrefs.DeleteAll();
        R.text = timeRemainingText + Math.Floor(timeR) + "s"; 
        if(Score == maxScore) 
        {
            if (activeScene == "Easy"){
                int F=1;
                int i = 0;
                while(F==1){
                    i++;
                    String ESS = "E" + i;
                    if(timeR > PlayerPrefs.GetFloat(ESS)){
                        for(int i2 = 10; i2 > i; i2--){
                            String OHighScore = "E"+i2;//E10
                            int ii = i2-1;
                            String NHighScore = "E"+ii;//E9
                            float NScore = PlayerPrefs.GetFloat(NHighScore);
                            PlayerPrefs.SetFloat(OHighScore, NScore);
                        }
                        PlayerPrefs.SetFloat(ESS, (float)Math.Round((double)timeR,3));
                        F=2;
                    }
                    if(i==10)F=2;
                }

            }
            else if (activeScene == "Medium"){
                int F=1;
                int i = 0;
                while(F==1){
                    i++;
                    String ESS = "M" + i;
                    if(timeR > PlayerPrefs.GetFloat(ESS)){
                        for(int i2 = 10; i2 > i; i2--){
                            String OHighScore = "M"+i2;//E10
                            int ii = i2-1;
                            String NHighScore = "M"+ii;//E9
                            float NScore = PlayerPrefs.GetFloat(NHighScore);
                            PlayerPrefs.SetFloat(OHighScore, NScore);
                        }
                        PlayerPrefs.SetFloat(ESS, (float)Math.Round((double)timeR,3));
                        F=2;
                    }
                    if(i==10)F=2;
                }
            }
            else if (activeScene == "Hard"){
                int F=1;
                int i = 0;
                while(F==1){
                    i++;
                    String ESS = "H" + i;
                    if(timeR > PlayerPrefs.GetFloat(ESS)){
                        for(int i2 = 10; i2 > i; i2--){
                            String OHighScore = "H"+i2;//E10
                            int ii = i2-1;
                            String NHighScore = "H"+ii;//E9
                            float NScore = PlayerPrefs.GetFloat(NHighScore);
                            PlayerPrefs.SetFloat(OHighScore, NScore);
                        }
                        PlayerPrefs.SetFloat(ESS, (float)Math.Round((double)timeR,3));
                        F=2;
                    }
                    if(i==10)F=2;
                }
            }

            if (sceneSaver.resume != "")
            {
                SceneManager.UnloadSceneAsync(sceneSaver.resume);
                if (Time.timeScale == 0)
                {
                    Time.timeScale = sceneSaver.oldTimeScale;
                    sceneSaver.oldTimeScale = 0;
                }
                sceneSaver.eventSystem.enabled = true;
                sceneSaver.audioListener.enabled = true;
                sceneSaver.resume = "";
            }

            SceneManager.LoadScene("Victory");
        }    
        
        // TIMERIN PÄIVITYS
        if(timeR > 0)
        {
            timeR -= Time.deltaTime;
        }

        else if(timeR <= 0) 
        {
            if (sceneSaver.resume != "")
            {
                SceneManager.UnloadSceneAsync(sceneSaver.resume);
                if (Time.timeScale == 0)
                {
                    Time.timeScale = sceneSaver.oldTimeScale;
                    sceneSaver.oldTimeScale = 0;
                }
                sceneSaver.eventSystem.enabled = true;
                sceneSaver.audioListener.enabled = true;
                sceneSaver.resume = "";
            }

            SceneManager.LoadScene("Failure");
        }
    }
}
