using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYR_ClearSmokebomb : MonoBehaviour
{

    private GameObject Player;
    //private PLYR_Health playerHP;

    //// Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPS Player");
        //playerHP = Player.GetComponent<PLYR_Health>();
        StartCoroutine(ClearCoroutine());

    }

    IEnumerator ClearCoroutine()
    {
        yield return new WaitForSeconds(8f);

        Destroy(gameObject);

    }


    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject == Player)
        {
            NPC_EnemySight.heatLevel = 0; // clear heat and should also halt aggro
        }

    }

}
