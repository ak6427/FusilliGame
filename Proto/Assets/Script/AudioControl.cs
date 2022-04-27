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

    public void Setup(AudioMixer mixer, string volumeName, bool muted, float storedSlider)
    {
        this.mixer = mixer;
        this.volumeName = volumeName;

        Debug.Log("volumeName: " + volumeName);

        mixer.GetFloat(volumeName, out float volume);

        if (muted == false)
        {
            slider.value = volume;
            Debug.Log("volume: " + volume);
        }
        else if (muted == true)
        {
            slider.value = storedSlider;
            Debug.Log("storedSlider: " + storedSlider);
            Debug.Log("volume: " + volume);
        }
    }

    public float Save(AudioMixer mixer, string volumeName, bool muted, float storedSlider, string prefVolume, string prefSlider)
    {
        if (muted == false)
        {
            mixer.SetFloat(volumeName, slider.value);
            PlayerPrefs.SetFloat(prefVolume, slider.value);
            return 0;
        }
        else 
        {
            PlayerPrefs.SetFloat(prefSlider, slider.value);
            return storedSlider = slider.value;
        }
    }
}
