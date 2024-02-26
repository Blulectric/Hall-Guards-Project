using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityLights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NPC_EnemyBehavior.attacking == true)
        {
            gameObject.GetComponent<Light>().color = new Color(1.0f, 0, 0); //red
        }
        else
        {
            gameObject.GetComponent<Light>().color = new Color(1.0f, 1.0f, 1.0f); //not red
        }
    }
}
