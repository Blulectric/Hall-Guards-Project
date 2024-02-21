using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_EnemySight : MonoBehaviour
{

    public UI_NoticeIcon NoticeIcon;

    public Transform sightOrigin;
    public Light sightLight;

    public bool inSight = false;
    //public bool hostile = false; // light should turn red and it will continue to follow player directly overhead, making alarm noise

    public int heatLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        aggroState();

    }




    //get collision point of the sight cone, then cast a ray to the collision point to see if player is visible, should be accurate enough for what we need.
    private void OnTriggerStay(Collider collider)
    {
        var collisionPoint = collider.ClosestPoint(transform.position);
        Vector3 direction = (collisionPoint - sightOrigin.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(sightOrigin.position, direction, out hit, Mathf.Infinity) && hit.transform.gameObject.tag == "Player")
        {
            inSight = true;
            NoticeIcon.enemiesNoticed.Add(gameObject); //good yes its adding, next fix the duplicates issue and hope that .Remove knows which one to remove... then check if UINoticeIcons script is seeing the right position (test moving enemy around while that script debugs the list item's transform pos)
        }
        else
        {
            inSight = false;
            //NoticeIcon.enemiesNoticed.Remove(gameObject);
        }

    }
    private void OnTriggerExit(Collider collider)
    {
        inSight = false;
    }



    void aggroState()
    {
        if (inSight)
        {
            sightLight.color = new Color(1.0f, 0.8f, 0); //bombastic orangeish yellow
            heatLevel = Mathf.Clamp(heatLevel + 1,0,100);
            updateAlertUIPos();
        }
        else
        {
            sightLight.color = new Color(0, 1.0f, 0.5f); //epic baja blast blue
            heatLevel = Mathf.Clamp(heatLevel - 1, 0, 100);
        }
        Debug.Log(heatLevel);
        if (heatLevel >= 100)
        {
            sightLight.color = new Color(1.0f, 0, 0); //red
        }
    }

    //updates the position of the on-screen display showing the enemy's detection level
    void updateAlertUIPos()
    {

    }

    void lightflicker()
    {

    }

}

