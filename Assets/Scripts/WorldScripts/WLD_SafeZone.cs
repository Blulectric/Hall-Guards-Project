using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLD_SafeZone : MonoBehaviour
{
    private GameObject Player;

    //// Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPS Player");
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject == Player)
        {
            NPC_EnemySight.heatLevel = 0; // clear heat and should also halt aggro
        }

    }

}
