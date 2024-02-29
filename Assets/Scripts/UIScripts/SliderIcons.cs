using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderIcons : MonoBehaviour
{
    public Image musicIcon, sfxIcon;
    public Sprite musicOn, musicOff, soundOn, soundOff;

    public Slider musicSlider, sfxSlider;

    public static float _musicVolume, _sfxVolume;

    public void ChangeMusicIcon()
    {
        if (musicSlider.value == musicSlider.minValue)
        {
            musicIcon.sprite = musicOff;
        } else 
        {
            musicIcon.sprite = musicOn;
        }
    }

    public void ChangeSFXIcon()
    {
        if (sfxSlider.value == sfxSlider.minValue)
        {
            sfxIcon.sprite = soundOff;
        } else 
        {
            sfxIcon.sprite = soundOn;
        }
    }
}
