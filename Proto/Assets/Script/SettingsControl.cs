using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsControl : MonoBehaviour
{
    public SceneSaver sceneSaver;
    //public GameObject saveSceneForRetry;
    
    [SerializeField]
    public GameObject BGMControlGO;
    private AudioControl BGMControlAC;

    [SerializeField]
    public GameObject SFXControlGO;
    private AudioControl SFXControlAC;

    [SerializeField]
    public string BGMVolumeName;

    [SerializeField]
    public string SFXVolumeName;

    [SerializeField]
    public AudioMixer mixer;

    [SerializeField]
    public GameObject BGMMuteButton;
    
    [SerializeField]
    public GameObject BGMUnmuteButton;
    
    [SerializeField]
    public Image BGMControlSlider;
    
    [SerializeField]
    public Image BGMControlBackground;
    
    [SerializeField]
    public Image BGMControlFill;
    
    [SerializeField]
    public GameObject SFXMuteButton;
    
    [SerializeField]
    public GameObject SFXUnmuteButton;
    
    [SerializeField]
    public Image SFXControlSlider;
    
    [SerializeField]
    public Image SFXControlBackground;
    
    [SerializeField]
    public Image SFXControlFill;

    private void Awake()
    {
        
        sceneSaver = FindObjectOfType<SceneSaver>();
        BGMControlAC = BGMControlGO.GetComponent<AudioControl>();
        SFXControlAC = SFXControlGO.GetComponent<AudioControl>();
    }

    private void Start()
    {
        if (sceneSaver.mutedBGM == false)
        {
            BGMControlAC.Setup(mixer, BGMVolumeName);
        }
        if (sceneSaver.mutedSFX == false)
        {
            SFXControlAC.Setup(mixer, SFXVolumeName);
        }
    }

    public void MuteBGM()
    {
        sceneSaver.mutedBGM = true;
        mixer.SetFloat(BGMVolumeName, -80);
        BGMMuteButton.SetActive(false);
        BGMUnmuteButton.SetActive(true);
        BGMControlSlider.color = new Color32(255, 255, 0, 105);
        BGMControlBackground.color = new Color32(255, 0, 0, 105);
        BGMControlFill.color = new Color32(0, 255, 0, 105);
    }

    public void UnmuteBGM()
    {
        sceneSaver.mutedBGM = false;
        mixer.SetFloat(BGMVolumeName, 0);
        BGMUnmuteButton.SetActive(false);
        BGMMuteButton.SetActive(true);
        BGMControlSlider.color = new Color32(255, 255, 0, 255);
        BGMControlBackground.color = new Color32(255, 0, 0, 255);
        BGMControlFill.color = new Color32(0, 255, 0, 255);
    }

    public void MuteSFX()
    {
        sceneSaver.mutedSFX = true;
        mixer.SetFloat(SFXVolumeName, -80);
        SFXMuteButton.SetActive(false);
        SFXUnmuteButton.SetActive(true);
        SFXControlSlider.color = new Color32(255, 255, 0, 105);
        SFXControlBackground.color = new Color32(255, 0, 0, 105);
        SFXControlFill.color = new Color32(0, 255, 0, 105);
    }

    public void UnmuteSFX()
    {
        sceneSaver.mutedSFX = false;
        mixer.SetFloat(SFXVolumeName, 0);
        SFXUnmuteButton.SetActive(false);
        SFXMuteButton.SetActive(true);
        SFXControlSlider.color = new Color32(255, 255, 0, 255);
        SFXControlBackground.color = new Color32(255, 0, 0, 255);
        SFXControlFill.color = new Color32(0, 255, 0, 255);
    }

    public void Close()
    {
        if (sceneSaver.mutedSFX == false)
        {
            BGMControlAC.Save();
        }
        if (sceneSaver.mutedSFX == false)
        {
            SFXControlAC.Save();
        }
    }
}
