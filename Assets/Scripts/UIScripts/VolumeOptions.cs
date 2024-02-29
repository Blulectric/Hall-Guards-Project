using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeOptions : MonoBehaviour
{
    //public Slider musicSlider, sfxSlider;
    public AudioMixer musicMixer, sfxMixer;
    
    public void MusicVolume(float volume)
    {
        musicMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        //Debug.Log($"Music Volume: {volume}");
    }

    public void SFXVolume(float volume)
    {
        sfxMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        //Debug.Log($"SFX Volume: {volume}");
    }
}
