using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    private AudioMixer mixer;
    private Slider slider;
    private string volumeName;
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private float ToDB(float linear)
    {
        return linear <= 0 ? -80f : Mathf.Log10(linear) * 20f;
    }

    private float ToLinear(float db)
    {
        return Mathf.Clamp01(Mathf.Pow(10.0f, db / 20.0f));
    }

    public void Setup(AudioMixer mixer, string volumeName, bool muted, float storedSlider)
    {
        this.mixer = mixer;
        this.volumeName = volumeName;

        mixer.GetFloat(volumeName, out float volume);

        if (muted == false)
        {
            slider.value = ToLinear(volume);
        }
        else if (muted == true)
        {
            slider.value = ToLinear(storedSlider);
        }
    }

    public float Save(AudioMixer mixer, string volumeName, bool muted, float storedSlider, string prefVolume, string prefSlider, float clampMax)
    {
        if (muted == false)
        {
            mixer.SetFloat(volumeName, Mathf.Clamp(ToDB(slider.value), -80, clampMax));
            PlayerPrefs.SetFloat(prefVolume, ToDB(slider.value));
            return 0;
        }
        else 
        {
            PlayerPrefs.SetFloat(prefSlider, ToDB(slider.value));
            return storedSlider = ToDB(slider.value);
        }
    }
}
