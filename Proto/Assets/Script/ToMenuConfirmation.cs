using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class ToMenuConfirmation : MonoBehaviour
{
    public TMP_Text childText;
    public SceneSwitch sceneSwitch;
    public float confirmTimer = 0.0f;
    private string askConfirmText;
    private string beforeConfirmText;
    public SceneSaver sceneSaver;

    void Awake()
    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        sceneSwitch = sceneSwitch.GetComponent<SceneSwitch>();
        sceneSaver = FindObjectOfType<SceneSaver>();
    }

    void Start()
	{
        askConfirmText = sceneSaver.localizedConfirm.GetLocalizedString();
        beforeConfirmText = sceneSaver.localizedMenu.GetLocalizedString();
	}

	public void ConfirmOrSetTimer()
    {
        if (confirmTimer == 0.0f)
        {
            confirmTimer = 3.0f;
        }
        else
        {
            sceneSwitch.SceneValikko();
        }
    }

    void Update()
    {
        if (confirmTimer > 0.0f)
        {
            childText.text = askConfirmText;
            childText.color = new Color(255, 255, 0, 255);
            childText.fontSize = 52.5f;
            confirmTimer = Mathf.Clamp(confirmTimer - Time.deltaTime, 0.0f, 3.0f);
        }
        else
        {
            childText.text = beforeConfirmText;
            childText.color = new Color(255, 0, 0, 255);
        }
        /*if (!localeSet && LocalizationSettings.SelectedLocale != null)
        {
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
			{
				askConfirmText = "Vahvista?";
				beforeConfirmText = "Valikko";
			}
			else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
			{
				askConfirmText = "Confirm?";
				beforeConfirmText = "Menu";
			}
            localeSet = true;
        }*/
    }
}
