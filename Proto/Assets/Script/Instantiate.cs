using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Instantiate : MonoBehaviour
{

    [SerializeField]
    public AudioMixer mixer;
    public GameObject DB;
    public GameObject SaveSceneForRetry;
    public GameObject DataContainer;
    public SceneSaver sceneSaver;
    
    void Awake()
    {
        Instantiate(DB);
        Instantiate(SaveSceneForRetry);
        sceneSaver = FindObjectOfType<SceneSaver>();
        Instantiate(DataContainer);
    }
    void Start()
    {  
        //PlayerPrefs.DeleteAll();

        // TUTORIAL
        if (PlayerPrefs.GetInt("tutorialSeen") == 0)
        {
            SceneManager.LoadScene("Info");
            PlayerPrefs.SetInt("tutorialSeen", 1);
        }
        else if (PlayerPrefs.GetInt("tutorialSeen") == 1)
        {
            SceneManager.LoadScene("Valikko");
        }

        // MIXER
        // CHECK MUTES
        if (PlayerPrefs.GetInt("mutedBGM") == 1)
        {
            mixer.SetFloat("BGMVolume", -80);
            sceneSaver.mutedBGM = true;
            sceneSaver.storedSliderBGM = PlayerPrefs.GetFloat("prefSliderBGM");
        }
        else
        {
            mixer.SetFloat("BGMVolume", Mathf.Clamp(PlayerPrefs.GetFloat("prefVolumeBGM"), -80, 0));
            sceneSaver.mutedBGM = false;
        }
        if (PlayerPrefs.GetInt("mutedSFX") == 1)
        {
            mixer.SetFloat("SFXVolume", -80);
            sceneSaver.mutedSFX = true;
            sceneSaver.storedSliderSFX = PlayerPrefs.GetFloat("prefSliderSFX");
        }
        else
        {
            mixer.SetFloat("SFXVolume", Mathf.Clamp(PlayerPrefs.GetFloat("prefVolumeSFX"), -80, 0));
            sceneSaver.mutedSFX = false;
        }

    }
}
