using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public Animator ladder;

    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ladder.SetTrigger("StartLadder");
            AudioManager.Instance.PlaySFX("plane");
            Destroy(this.gameObject);
        }
    }
}
