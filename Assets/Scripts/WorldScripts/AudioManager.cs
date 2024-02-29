using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    //public AudioMixer musicMixer, sfxMixer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        } else 
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        PlayMusic("Stealth Music");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning($"Sound {name} Not Found!");
            return;
        } else
        {
            musicSource.clip = s.clip;
            musicSource.loop = s.loop;
            musicSource.volume = s.volume;
            musicSource.Play();
            Debug.Log("Music Clip Played!");
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning($"Sound {name} Not Found!");
            return;
        } else
        {
            sfxSource.clip = s.clip;
            sfxSource.volume = s.volume;
            sfxSource.Play();
            Debug.Log("SFX Clip Played!");
        }
    }
}
