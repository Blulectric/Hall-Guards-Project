using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioTracker", menuName = "ScriptableObjects/Audio Tracker", order = 1)]
public class AudioTracker : ScriptableObject
{
    [Range(0.0001f, 1f)]
    public float sfxValue, musicValue;

    public UnityEvent<float> trackerChangeEvent;

    private void OnEnable()
    {
        if (trackerChangeEvent == null)
        {
            trackerChangeEvent = new UnityEvent<float>();
        }
    }

    public void UpdateSFXValue(float value)
    {
        sfxValue = value;
        trackerChangeEvent.Invoke(sfxValue);
    }

    public void UpdateMusicValue(float value)
    {
        musicValue = value;
        trackerChangeEvent.Invoke(musicValue);
    }
}
