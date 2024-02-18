using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{

    public Transform sightOrigin;
    public Light sightLight;

    public bool inSight = false;
    public bool hostile = false; // light should turn red and it will continue to follow player directly overhead, making alarm noise

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
        }
        else
        {
            inSight = false;
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
            sightLight.color = new Color(1.0f, 0.8f, 0);
        }
        else
        {
            sightLight.color = new Color(0, 1.0f, 0.5f);
        }
    }


    void lightflicker()
    {

    }

}

