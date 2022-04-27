using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instantiate : MonoBehaviour
{
    public GameObject DB;
    public GameObject SaveSceneForRetry;

    public GameObject DataContainer;
    private int tutorialSeen = 0; //0 = false, 1 = true
    
    void Awake()
    {
        Instantiate(DB);
        Instantiate(SaveSceneForRetry);
        Instantiate(DataContainer);
    }
    void Start()
    {  
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("tutorialSeen") == 0)
        {
            SceneManager.LoadScene("Info");
            PlayerPrefs.SetInt("tutorialSeen", 1);
        }
        else if (PlayerPrefs.GetInt("tutorialSeen") == 1)
        {
            SceneManager.LoadScene("Valikko");
        }
    }
}
