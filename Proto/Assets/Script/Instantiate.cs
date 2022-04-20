using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instantiate : MonoBehaviour
{
    public GameObject DB;
    public GameObject SaveSceneForRetry;
    void Awake()
    {
        Instantiate(DB);
        Instantiate(SaveSceneForRetry);
    }
    void Start()
    {
        
        SceneManager.LoadScene("Valikko");
    }
}
