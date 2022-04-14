using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GetScores : MonoBehaviour
{
    public TMP_Text Easy;
    public TMP_Text Medium;
    public TMP_Text Hard; 

    // Start is called before the first frame update
    void Start()
    {
        Easy.text = "1. "+PlayerPrefs.GetFloat("E1")+"\n"+"2. "+PlayerPrefs.GetFloat("E2")+"\n"+"3. "+PlayerPrefs.GetFloat("E3")+"\n"+"4. "+PlayerPrefs.GetFloat("E4")+"\n"+"5. "+PlayerPrefs.GetFloat("E5")+"\n"+"6. "+PlayerPrefs.GetFloat("E6")+"\n"+"7. "+PlayerPrefs.GetFloat("E7")+"\n"+"8. "+PlayerPrefs.GetFloat("E8")+"\n"+"9. "+PlayerPrefs.GetFloat("E9")+"\n"+"10. "+PlayerPrefs.GetFloat("E10")+"\n";
        Medium.text  = "1. "+PlayerPrefs.GetFloat("M1")+"\n"+"2. "+PlayerPrefs.GetFloat("M2")+"\n"+"3. "+PlayerPrefs.GetFloat("M3")+"\n"+"4. "+PlayerPrefs.GetFloat("M4")+"\n"+"5. "+PlayerPrefs.GetFloat("M5")+"\n"+"6. "+PlayerPrefs.GetFloat("M6")+"\n"+"7. "+PlayerPrefs.GetFloat("M7")+"\n"+"8. "+PlayerPrefs.GetFloat("M8")+"\n"+"9. "+PlayerPrefs.GetFloat("M9")+"\n"+"10. "+PlayerPrefs.GetFloat("M10")+"\n";
        Hard.text = "1. "+PlayerPrefs.GetFloat("H1")+"\n"+"2. "+PlayerPrefs.GetFloat("H2")+"\n"+"3. "+PlayerPrefs.GetFloat("H3")+"\n"+"4. "+PlayerPrefs.GetFloat("H4")+"\n"+"5. "+PlayerPrefs.GetFloat("H5")+"\n"+"6. "+PlayerPrefs.GetFloat("H6")+"\n"+"7. "+PlayerPrefs.GetFloat("H7")+"\n"+"8. "+PlayerPrefs.GetFloat("H8")+"\n"+"9. "+PlayerPrefs.GetFloat("H9")+"\n"+"10. "+PlayerPrefs.GetFloat("H10")+"\n";
    }


}