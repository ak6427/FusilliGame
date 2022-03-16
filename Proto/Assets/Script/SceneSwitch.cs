 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
public class SceneSwitch : MonoBehaviour
{
    private SceneSaver sceneSaver;

    // Start is called before the first frame update
    void Start()
    {
       sceneSaver = FindObjectOfType<SceneSaver>();
    }

    public void ScenePeli() {
        SceneManager.LoadScene("Peli");
    }
    public void SceneValikko() {
        SceneManager.LoadScene("Valikko");
    }
    public void SceneEasy() {
        sceneSaver.retry = "Easy";
        SceneManager.LoadScene("Easy");
    }
    public void SceneMedium() {
        sceneSaver.retry = "Medium";
        SceneManager.LoadScene("Medium");
    }
    public void SceneHard() {
        sceneSaver.retry = "Hard";
        SceneManager.LoadScene("Hard");
    }
    public void SceneExtreme() {
        sceneSaver.retry = "Extreme";
        SceneManager.LoadScene("Extreme");
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
        case "Extreme":
            SceneExtreme();
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
