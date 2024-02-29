using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/Audio Settings", order = 1)]
public class AudioSettings : ScriptableObject
{
    [Range(0f, 1f)]
    public float volume = Mathf.Clamp(1f, 0f, 1f);

    public UnityEvent<bool> audioChangeEvent;

    private void OnEnable()
    {
        if (audioChangeEvent == null)
        {
            audioChangeEvent = new UnityEvent<bool>();
        }
    }

    

}
