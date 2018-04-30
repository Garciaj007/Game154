using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name  && s != null)
            {
                s.source.Play();
            }
        }
    }

    public void Stop(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name && s != null)
            {
                s.source.Stop();
            }
        }
    }

    public void Pause(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name && s != null)
            {
                s.source.Pause();
            }
        }
    }

    public void Resume(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name && s != null)
            {
                s.source.UnPause();
            }
        }
    }

}


