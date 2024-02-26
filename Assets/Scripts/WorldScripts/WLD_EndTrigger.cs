using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLD_EndTrigger : MonoBehaviour
{

    private GameObject Player;

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
            Time.timeScale = 0f;
        }
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
