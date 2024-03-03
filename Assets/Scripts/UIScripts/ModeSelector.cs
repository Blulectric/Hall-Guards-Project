using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ModeSelector", menuName = "ScriptableObjects/Mode Selector", order = 1)]
public class ModeSelector : ScriptableObject
{
    public bool invisMode;
    public bool noLightMode;

    [SerializeField] private bool startInvis;
    [SerializeField] private bool startNoLight;

    public UnityEvent<bool> modeChangeEvent;

    private void OnEnable()
    {
        invisMode = startInvis;
        noLightMode = startNoLight;

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
