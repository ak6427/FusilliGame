using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneSaver : MonoBehaviour
{
    public string retry;
    public int levelPage = 1;
    public string resume = "";
    public EventSystem eventSystem;
    public AudioListener audioListener;
    public bool mutedBGM = false;
    public bool mutedSFX = false;
    public float storedSliderBGM;
    public float storedSliderSFX;
    public float oldTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
