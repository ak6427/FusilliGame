using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instantiate : MonoBehaviour
{
    public GameObject DB;
    public GameObject SaveSceneForRetry;

    public GameObject DataContainer;
    
    void Awake()
    {
        Instantiate(DB);
        Instantiate(SaveSceneForRetry);
        Instantiate(DataContainer);
    }
    void Start()
    {
        SceneManager.LoadScene("Info");
    }
}
