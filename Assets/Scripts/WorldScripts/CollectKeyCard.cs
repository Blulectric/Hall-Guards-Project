using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeyCard : MonoBehaviour
{

    public PromptTrigger promptTrigger; //the trigger gameobject containing the PromptTrigger script

    //public KeycardDoor DoorScript;
    public GameObject keycardDoorTrigger;
    private Vector3 intendedPosition;

    private bool triggered = false;


    void Start()
    {
        // Blocked out this code because it was causing a bug where picking up the keycard would use the door's active text, rather than the keycard's active text - Liz
        //intendedPosition = keycardDoorTrigger.transform.position; //get the intended position that the trigger should move to when the player has the keycard
        //keycardDoorTrigger.transform.position = new Vector3(keycardDoorTrigger.transform.position.x, keycardDoorTrigger.transform.position.y-20, keycardDoorTrigger.transform.position.z); //just shove it underground until player gets keycard

        keycardDoorTrigger.SetActive(false);
    }

        // Update is called once per frame
        void Update()
    {
        if (promptTrigger.completed == true && triggered == false)
        {
            triggered = true;
            //keycardDoorTrigger.transform.position = intendedPosition; //unbury the trigger and put it in front of the door
            keycardDoorTrigger.SetActive(true);
            Destroy(gameObject); 
        }
    }
}
