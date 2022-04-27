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
    public float pageOneScale;
    public float widthOrHeight;

    public LocalizedString localizedConfirm;

    public LocalizedString localizedMenu;

    public LocalizedString localizedTimeRemaining;

    [SerializeField]
    private LocalizedString localizedFoodColumn;
    public int localizedFoodColumnParsed;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        /*if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            askConfirmText = "Vahvista?";
            beforeConfirmText = "Valikko";
            timeRemainingText = "Aikaa jäljellä: ";
            foodColumn = 0;
        }
        else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            askConfirmText = "Confirm?";
            beforeConfirmText = "Menu";
            timeRemainingText = "Time remaining: ";
            foodColumn = 1;
        }*/

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

    void Update()
    {
        localizedFoodColumnParsed = int.Parse(localizedFoodColumn.GetLocalizedString());
    }

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
    }

    private void OnDisable()
    {   
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }

    OnLocaleChanged(Locale obj)
    {

    }
}
