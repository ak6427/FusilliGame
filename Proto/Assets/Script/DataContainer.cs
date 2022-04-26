using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DataContainer : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    public static DataContainer Current
    {
        get;
        private set;
    }

    public AudioMixer Mixer
    {
        get { return mixer; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Current == null)
        {
            Current = this;
        }
        else if (Current != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
