using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light light;

    [SerializeField]
    private float maxIntensitySmall = 1.5f;
    [SerializeField]
    private float maxIntensityBig = 3f;

    public MonitorSize monitorDropdown = new MonitorSize();

    public enum MonitorSize
    {
        Small,
        Big
    };

    // Update is called once per frame
    void Update()
    {
        if (monitorDropdown == MonitorSize.Small) 
        {
            light.intensity = Mathf.PingPong(Time.time/2, maxIntensitySmall);
        }

        if (monitorDropdown == MonitorSize.Big)
        {
            light.intensity = Mathf.PingPong(Time.time, maxIntensityBig);
        }
    }
}
