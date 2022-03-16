 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
public class SceneSwitch : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void ScenePeli() {
        SceneManager.LoadScene("Peli");
    }
    public void SceneValikko() {
        SceneManager.LoadScene("Valikko");
    }
    public void SceneEasy() {
        SceneManager.LoadScene("Easy");
    }
    public void SceneMedium() {
        SceneManager.LoadScene("Medium");
    }
    public void SceneHard() {
        SceneManager.LoadScene("Hard");
    }
    public void SceneExtreme() {
        SceneManager.LoadScene("Extreme");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
