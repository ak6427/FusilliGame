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
        Easy.text = "[1] "+PlayerPrefs.GetFloat("E1")+"s\n"+"[2] "+PlayerPrefs.GetFloat("E2")+"s\n"+"[3] "+PlayerPrefs.GetFloat("E3")+"s\n"+"[4] "+PlayerPrefs.GetFloat("E4")+"s\n"+"[5] "+PlayerPrefs.GetFloat("E5")+"s\n"+"[6] "+PlayerPrefs.GetFloat("E6")+"s\n"+"[7] "+PlayerPrefs.GetFloat("E7")+"s\n"+"[8] "+PlayerPrefs.GetFloat("E8")+"s\n"+"[9] "+PlayerPrefs.GetFloat("E9")+"s\n"+"[10] "+PlayerPrefs.GetFloat("E10")+"s\n";
        Medium.text  = "[1] "+PlayerPrefs.GetFloat("M1")+"s\n"+"[2] "+PlayerPrefs.GetFloat("M2")+"s\n"+"[3] "+PlayerPrefs.GetFloat("M3")+"s\n"+"[4] "+PlayerPrefs.GetFloat("M4")+"s\n"+"[5] "+PlayerPrefs.GetFloat("M5")+"s\n"+"[6] "+PlayerPrefs.GetFloat("M6")+"s\n"+"[7] "+PlayerPrefs.GetFloat("M7")+"s\n"+"[8] "+PlayerPrefs.GetFloat("M8")+"s\n"+"[9] "+PlayerPrefs.GetFloat("M9")+"s\n"+"[10] "+PlayerPrefs.GetFloat("M10")+"s\n";
        Hard.text = "[1] "+PlayerPrefs.GetFloat("H1")+"s\n"+"[2] "+PlayerPrefs.GetFloat("H2")+"s\n"+"[3] "+PlayerPrefs.GetFloat("H3")+"s\n"+"[4] "+PlayerPrefs.GetFloat("H4")+"s\n"+"[5] "+PlayerPrefs.GetFloat("H5")+"s\n"+"[6] "+PlayerPrefs.GetFloat("H6")+"s\n"+"[7] "+PlayerPrefs.GetFloat("H7")+"s\n"+"[8] "+PlayerPrefs.GetFloat("H8")+"s\n"+"[9] "+PlayerPrefs.GetFloat("H9")+"s\n"+"[10] "+PlayerPrefs.GetFloat("H10")+"s\n";
    }


}