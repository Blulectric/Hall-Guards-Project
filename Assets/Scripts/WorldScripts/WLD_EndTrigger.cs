using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLD_EndTrigger : MonoBehaviour
{
    private GameObject Player;

    public static bool WinGame = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FPS Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("Game end!");

            WinGame = true;
            //Time.timeScale = 0f;
        }
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
