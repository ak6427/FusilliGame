using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    [SerializeField] public int Score;
    void Update()
    {
        if(Score == 6){
            SceneManager.LoadScene("Victory");
        }    
    }
}
