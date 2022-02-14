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

    // Update is called once per frame
    void Update()
    {
        
    }
}
