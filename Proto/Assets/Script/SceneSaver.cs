using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

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
    public float widthOrHeight;
    public float newRecord;

    public LocalizedString localizedConfirm;

    public LocalizedString localizedMenu;

    public LocalizedString localizedTimeRemaining;

    [SerializeField]
    private LocalizedString localizedPageOneAnimation;

    [SerializeField]
    private LocalizedString localizedFoodColumn;
    public int localizedFoodColumnParsed;

    public int localeToggle = 0;
    
    public bool hideMenuBackground = false;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        localizedFoodColumnParsed = int.Parse(localizedFoodColumn.GetLocalizedString());

        float ratioX = (float)Screen.width / 1920;
        float ratioY = (float)Screen.height / 1080;
        if (ratioX >= ratioY)
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

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
    }

    private void OnDisable()
    {   
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }

    private void OnLocaleChanged(Locale obj)
    {
        if(localeToggle == 0)
        {
            localeToggle = 1;
        }
        else 
        {
            localeToggle = 0;
        }
    }
}
