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

        if (mixer.GetFloat(volumeName, out float volume) && muted == false)
        {
            slider.value = volume;
        }
        else if (muted == true)
        {
            slider.value = storedSlider;
        }
    }

    public float Save(bool muted, float storedSlider)
    {
        if (muted == false)
        {
            mixer.SetFloat(volumeName, slider.value);
            return 0;
        }
        else 
        {
            return storedSlider = slider.value;
        }
    }
}
