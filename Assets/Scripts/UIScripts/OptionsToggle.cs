using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsToggle : MonoBehaviour
{
    [SerializeField]
    private ModeSelector modes;
    [SerializeField]
    private AudioTracker audio;

    public Toggle invisToggle, noLightToggle;
    public Slider musicSlider, sfxSlider;

    public void Start()
    {
        if (modes.invisMode)
        {
            invisToggle.isOn = true;
            modes.invisMode = true;
        } else 
        {
            invisToggle.isOn = false;
            modes.invisMode = false;
        }

        if (modes.noLightMode)
        {
            noLightToggle.isOn = true;
            modes.noLightMode = true;
        } else
        {
            noLightToggle.isOn = false;
            modes.noLightMode = false;
        }

        musicSlider.value = audio.musicValue;
        sfxSlider.value = audio.sfxValue;
    }
}
