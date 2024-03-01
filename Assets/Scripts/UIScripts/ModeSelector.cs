using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ModeSelector", menuName = "ScriptableObjects/Mode Selector", order = 1)]
public class ModeSelector : ScriptableObject
{
    public bool invisMode;
    public bool noLightMode;

    public UnityEvent<bool> modeChangeEvent;

    private void OnEnable()
    {
        invisMode = false;
        noLightMode = false;

        if (modeChangeEvent == null)
        {
            modeChangeEvent = new UnityEvent<bool>();
        }
    }

    public void ChangeInvisStatus()
    {
        invisMode = !invisMode;
        modeChangeEvent.Invoke(invisMode);
        Debug.Log($"Invis Mode: {invisMode}");
    }

    public void ChangeNoLightStatus()
    {
        noLightMode = !noLightMode;
        modeChangeEvent.Invoke(noLightMode);
        Debug.Log($"No Light Mode: {noLightMode}");
    }

}
