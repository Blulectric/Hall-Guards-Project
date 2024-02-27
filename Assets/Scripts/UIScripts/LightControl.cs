using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject[] Lights;

    [SerializeField]
    private float lightIntensity = 1.5f;
    
    [SerializeField]
    private ModeSelector modes;

    // Update is called once per frame
    void Update()
    {
        LightMode();
    }

    private void LightMode()
    {
        foreach (GameObject gO in Lights)
        {
            Light light = gO.GetComponent<Light>();

            if (light != null && modes.noLightMode) 
            {
                light.intensity = 0f;
            } else 
            {
                light.intensity = lightIntensity;
            }
        }
    }
}
