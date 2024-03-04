using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveKeeper : MonoBehaviour
{
    public GameObject objectiveBox;

    public TextMeshProUGUI objectiveText;

    void Start()
    {
        objectiveText.text = "Grab Keycard";
    }

    public void ChangeObjectiveText(string newText)
    {
        objectiveText.text = newText;
    }
}
