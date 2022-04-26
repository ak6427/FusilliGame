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
    public float pageOneScale;
    public float widthOrHeight;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        float ratioX = (float)Screen.width / 1920;
        float ratioY = (float)Screen.height / 1080;
        if (ratioX > ratioY)
        {
            widthOrHeight = 0.75f;
        }
        else if (ratioX < ratioY)
        {
            widthOrHeight = 0.0f;
        }
        else 
        {
            widthOrHeight = 0.5f;
        }
    }
}
