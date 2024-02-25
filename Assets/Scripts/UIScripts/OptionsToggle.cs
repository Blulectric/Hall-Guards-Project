using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsToggle : MonoBehaviour
{
    [SerializeField]
    private ModeSelector modes;

    public Toggle invisToggle;
    public Toggle noLightToggle;

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
    }
}
