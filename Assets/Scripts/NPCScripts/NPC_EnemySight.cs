using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_EnemySight : MonoBehaviour
{

    //public UI_NoticeIcon NoticeIcon;
    public GameObject enemyBody;

    public Transform sightOrigin;

    public Light sightLight;

    public bool inSightofSelf = false; //sets true if just this object sees u

    public static bool inSightofAny = false; //global true used by the heatLevel script to make the heat level increase

    public static float heatLevel = 0;

    private Transform PlayerPos;

    public PLYR_Health playerHP;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.Find("FPS Player").transform;
        inSightofAny = false;
        heatLevel = 0;
    }


    // Update is called once per frame
    void Update()
    {

        whenInSight();

    }




    //get collision point of the sight cone, then cast a ray to the collision point to see if player is visible, should be accurate enough for what we need.
    private void OnTriggerStay(Collider collider)
    {
        var collisionPoint = collider.ClosestPoint(transform.position);
        Vector3 direction = (collisionPoint - sightOrigin.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(sightOrigin.position, direction, out hit, Mathf.Infinity) && hit.transform.gameObject.tag == "Player")
        {
            inSightofSelf = true;
            inSightofAny = true;
        }
        else
        {
            inSightofSelf = false;
            inSightofAny = false;
        }

    }
    private void OnTriggerExit(Collider collider)
    {
        inSightofSelf = false;
        inSightofAny = false;
    }



    void whenInSight()
    {


        if (inSightofSelf)
        {
            sightLight.color = new Color(1.0f, 0.8f, 0); //orange.
            enemyBody.transform.rotation = Quaternion.LookRotation(PlayerPos.position - enemyBody.transform.position); //look in direction of noticed player
        }
        else
        {
            sightLight.color = new Color(0, 1.0f, 0.5f); //blue.
        }
        if (NPC_EnemyBehavior.attacking)
        {
            sightLight.color = new Color(1.0f, 0, 0); //red.
        }


    }

    void lightflicker()
    {

    }

}

