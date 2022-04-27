using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class SceneSwitch : MonoBehaviour
{
    public SceneSaver sceneSaver;
    public string activeScene;
    public float oldTimeScale;

    // Start is called before the first frame update
    void Awake()
    {
       sceneSaver = FindObjectOfType<SceneSaver>();
    }

    public void SceneValikko() {
        if (sceneSaver.resume == "")
        {
            sceneSaver.levelPage = 1;
            SceneManager.LoadScene("Valikko");
        }
        else 
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
            sceneSaver.hideMenuBackground = false;
        }
    }
    public void ScenePeli() {
        SceneManager.LoadScene("Peli");
    }
    public void SceneEasy() {
        sceneSaver.retry = "Easy";
        sceneSaver.levelPage = 2;
        SceneManager.LoadScene("Easy");
    }
    public void SceneMedium() {
        sceneSaver.retry = "Medium";
        sceneSaver.levelPage = 3;
        SceneManager.LoadScene("Medium");
    }
    public void SceneHard() {
        sceneSaver.retry = "Hard";
        sceneSaver.levelPage = 4;
        SceneManager.LoadScene("Hard");
    }
    public void SceneScores() {
        SceneManager.LoadScene("Scores");
    }
    public void SceneInfo() {
        sceneSaver.pageOneScale = 1;
        SceneManager.LoadScene("Info");
    }
    public void SceneSettings() {
        SceneManager.LoadScene("Settings");
    }
    public void SceneInfoAsync() {
        sceneSaver = FindObjectOfType<SceneSaver>();
        sceneSaver.eventSystem.enabled = false;
        sceneSaver.audioListener.enabled = false;
        sceneSaver.resume = "Info";
        sceneSaver.pageOneScale = 1.17f;
        sceneSaver.hideMenuBackground = true;
        SceneManager.LoadSceneAsync("Info", LoadSceneMode.Additive);
    }
    public void SceneSettingsAsync() {
        sceneSaver.oldTimeScale = Time.timeScale;
        Time.timeScale = 0;
        sceneSaver = FindObjectOfType<SceneSaver>();
        sceneSaver.eventSystem.enabled = false;
        sceneSaver.audioListener.enabled = false;
        sceneSaver.resume = "Settings";
        sceneSaver.hideMenuBackground = true;
        SceneManager.LoadSceneAsync("Settings", LoadSceneMode.Additive);
    }

    public void SceneRetry()
    {
        switch(sceneSaver.retry)
        {
        case "Easy":
            SceneEasy();
            break;
        case "Medium":
            SceneMedium();
            break;
        case "Hard":
            SceneHard();
            break;
        }
    }

    public void Update()
    {
        activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "Easy" || activeScene == "Medium" || activeScene == "Hard")
        {
            sceneSaver.eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            sceneSaver.audioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        }
    }
}
