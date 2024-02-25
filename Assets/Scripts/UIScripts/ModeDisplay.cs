using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeDisplay : MonoBehaviour
{
    public GameObject invisDisplay;
    public GameObject noLightDisplay;

    [SerializeField]
    private ModeSelector modes;

    void Update()
    {
        UpdateModesDisplay();
    }

    void UpdateModesDisplay()
    {
        if (modes.invisMode) 
        {
            invisDisplay.SetActive(true);
            //Debug.Log("Invis Mode is enabled!");
        } else 
        {
           invisDisplay.SetActive(false);
            //Debug.Log("Invis Mode is disabled!");
        }

        if (modes.noLightMode)
        {
            noLightDisplay.SetActive(true);
            //Debug.Log("No Light Mode is enabled!");
        } else
        {
            noLightDisplay.SetActive(false);
            //Debug.Log("Invis Mode is disabled!");
        }
    }
}
