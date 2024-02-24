using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLD_RunGunTrigger : MonoBehaviour
{

    public GameObject RunGunUI;

    private bool reached = false;

    public static bool GENOCIDE = false; //will change enemy behaviors slightly maybe

    // Start is called before the first frame update
    void Start()
    {
        GENOCIDE = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (GENOCIDE == false)
        {
            reached = true;
            RunGunUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0) && reached == true )
        {
            GENOCIDE = true;
            RunGunUI.SetActive(false);
            Time.timeScale = 1f;
        }

        if (GENOCIDE == true)
        {
            NPC_EnemySight.heatLevel = 100; //force enemies to always attack
        }

    }
}
