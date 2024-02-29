using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLD_RunGunTrigger : MonoBehaviour
{

    public GameObject RunGunUI;
    //public GameObject RunGunCrosshairUI;

    private bool reached = false;

    private GameObject Player;

    public static bool GENOCIDE = false; //will change enemy behaviors slightly maybe

    [SerializeField]
    private ModeSelector modes;

    // Start is called before the first frame update
    void Start()
    {
        GENOCIDE = false;
        Player = GameObject.Find("FPS Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (GENOCIDE == false && other.gameObject == Player)
        {
            reached = true;
            RunGunUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reached == true && GENOCIDE == false)
        {
            Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
            GENOCIDE = true;
            RunGunUI.SetActive(false);
            //RunGunCrosshairUI.SetActive(true);
            FindObjectOfType<AudioManager> ().StopPlaying ("Stealth Music");
            FindObjectOfType<AudioManager>().Play("Run Music");
            Time.timeScale = 1f;

        }

        if (GENOCIDE == true && !modes.invisMode)
        {
            NPC_EnemySight.heatLevel = 100; //force enemies to always attack
        }

    }
}
