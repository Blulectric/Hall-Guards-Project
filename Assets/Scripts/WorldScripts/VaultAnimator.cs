using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultAnimator : MonoBehaviour
{
    public Animator vaultOpen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            vaultOpen.SetTrigger("Open");
        }
    }
}
