using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class SelectLocale : MonoBehaviour
{
    [SerializeField]
    private Locale locale;

    private SceneSaver sceneSaver;

    void Awake()
    {
        sceneSaver = FindObjectOfType<SceneSaver>();
    }

    public void SetLocale()
    {
        LocalizationSettings.SelectedLocale = locale;
        /*if (locale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            sceneSaver.askConfirmText = "Vahvista?";
            sceneSaver.beforeConfirmText = "Valikko";
            sceneSaver.timeRemainingText = "Aikaa jäljellä: ";
            sceneSaver.foodColumn = 0;
        }
        else if (locale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            sceneSaver.askConfirmText = "Confirm?";
            sceneSaver.beforeConfirmText = "Menu";
            sceneSaver.timeRemainingText = "Time remaining: ";
            sceneSaver.foodColumn = 1;
        }*/
    }
}
