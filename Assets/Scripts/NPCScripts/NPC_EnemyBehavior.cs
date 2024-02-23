using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_EnemyBehavior : MonoBehaviour
{

    private Camera cam;
    public NavMeshAgent agent;

    public int HP = 100;


    public ParticleSystem explosionParticleBurst;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Debug.Log(cam);
    }

    // Update is called once per frame
    void Update()
    {

        NavMeshMovementStuff();

        if (HP<=0)
        {
            //explosionParticleBurst.Play(); //play a particle here
            Destroy(gameObject);
        }

    }




    void NavMeshMovementStuff()
    {
        //a very basic setup to test to navmesh agent movement, click the ground to move enemy there
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(2)) //debug test enemy death
        {
            HP = 0;
        }
    }

}

