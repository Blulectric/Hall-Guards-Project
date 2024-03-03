using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardDoor : MonoBehaviour
{
    public Animator vaultOpen;

    public Animation slidingDoorAnim;

    public PromptTrigger promptTrigger; //the trigger gameobject containing the PromptTrigger script

    private bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if (promptTrigger.completed == true && triggered == false)
        {
            triggered = true;
            //i'll play Azalee's door sliding animation here but idk if this even is the right code for it ;-;
            //animation["AnimationName"].wrapMode = WrapMode.Once;
            //animation.Play("AnimationName");
            vaultOpen.SetTrigger("Open");

            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            vaultOpen.SetTrigger("Open");
        }
    }





}
