using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFX : MonoBehaviour
{
    private AudioSource audioSource;
    private SceneSwitch sceneSwitch;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }

    // CLOSE / MAIN MENU

    public void PlaySFXClose()
    {
        audioSource.Play();
        StartCoroutine(WaitClose());
    }

    private IEnumerator WaitClose()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneValikko();
    }

    // TO MENU CONFIRMATION

    public void PlaySFXToMenuConfirmation()
    {
        audioSource.Play();
        StartCoroutine(WaitToMenuConfirmation());
    }

    private IEnumerator WaitToMenuConfirmation()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        GameObject.Find("SceneSwitch").GetComponent<ToMenuConfirmation>().ConfirmOrSetTimer();
    }

    // INFO OVERLAY

    public void PlaySFXInfoOverlay()
    {
        audioSource.Play();
        StartCoroutine(WaitInfoOverlay());
    }

    private IEnumerator WaitInfoOverlay()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneInfoAsync();
    }

    // SETTINGS OVERLAY

    public void PlaySFXSettingsOverlay()
    {
        audioSource.Play();
        StartCoroutine(WaitSettingsOverlay());
    }

    private IEnumerator WaitSettingsOverlay()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneSettingsAsync();
    }

    // DIFFICULTY

    public void PlaySFXDifficulty()
    {
        audioSource.Play();
        StartCoroutine(WaitDifficulty());
    }

    private IEnumerator WaitDifficulty()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.ScenePeli();
    }

    // TRY AGAIN

    public void PlaySFXTryAgain()
    {
        audioSource.Play();
        StartCoroutine(WaitTryAgain());
    }

    private IEnumerator WaitTryAgain()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneRetry();
    }

    // EASY

    public void PlaySFXEasy()
    {
        audioSource.Play();
        StartCoroutine(WaitEasy());
    }

    private IEnumerator WaitEasy()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneEasy();
    }

    // MEDIUM

    public void PlaySFXMedium()
    {
        audioSource.Play();
        StartCoroutine(WaitMedium());
    }

    private IEnumerator WaitMedium()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneMedium();
    }

    // HARD

    public void PlaySFXHard()
    {
        audioSource.Play();
        StartCoroutine(WaitHard());
    }

    private IEnumerator WaitHard()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneHard();
    }

    // INFO

    public void PlaySFXInfo()
    {
        audioSource.Play();
        StartCoroutine(WaitInfo());
    }

    private IEnumerator WaitInfo()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneInfo();
    }

    // SCORES

    public void PlaySFXScores()
    {
        audioSource.Play();
        StartCoroutine(WaitScores());
    }

    private IEnumerator WaitScores()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneScores();
    }

    // SETTINGS

    public void PlaySFXSettings()
    {
        audioSource.Play();
        StartCoroutine(WaitSettings());
    }

    private IEnumerator WaitSettings()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneSettings();
    }

    // QUIT

    public void PlaySFXQuit()
    {
        audioSource.Play();
        StartCoroutine(WaitQuit());
    }

    private IEnumerator WaitQuit()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        Application.Quit();
    }

    // MUTE BGM

    public void PlaySFXMuteBGM()
    {
        audioSource.Play();
        StartCoroutine(WaitMuteBGM());
    }

    private IEnumerator WaitMuteBGM()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        FindObjectOfType<SettingsControl>().MuteBGM();
    }

    // UNMUTE BGM

    public void PlaySFXUnmuteBGM()
    {
        audioSource.Play();
        StartCoroutine(WaitUnmuteBGM());
    }

    private IEnumerator WaitUnmuteBGM()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        FindObjectOfType<SettingsControl>().UnmuteBGM();
    }

    // MUTE SFX

    public void PlaySFXMuteSFX()
    {
        audioSource.Play();
        StartCoroutine(WaitMuteSFX());
    }

    private IEnumerator WaitMuteSFX()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        FindObjectOfType<SettingsControl>().MuteSFX();
    }

    // TURN RIGHT

    public void PlaySFXTurnRight()
    {
        audioSource.Play();
        StartCoroutine(WaitTurnRight());
    }

    private IEnumerator WaitTurnRight()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        FindObjectOfType<Info>().TurnRight();
    }

    // TURN LEFT

    public void PlaySFXTurnLeft()
    {
        audioSource.Play();
        StartCoroutine(WaitTurnLeft());
    }

    private IEnumerator WaitTurnLeft()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        FindObjectOfType<Info>().TurnLeft();
    }

    // CREDITS

    public void PlaySFXCredits()
    {
        audioSource.Play();
        StartCoroutine(WaitCredits());
    }

    private IEnumerator WaitCredits()
    {
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        StopAllCoroutines();
        sceneSwitch.SceneCredits();
    }
}
