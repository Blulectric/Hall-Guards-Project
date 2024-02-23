using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_EnemyBehavior : MonoBehaviour
{

    private Camera cam;
    public NavMeshAgent agent;

    private Vector3 HomePosition;
    private Transform PlayerPos;
    public float wanderDelay = 5f;
    private float wanderTimer = 0f;
    public int wanderRange = 10;
    public GameObject wanderRegion;

    public static bool attacking = false; // all enemies will attack if this is true

    public int HP = 100;


    public MyEnum myDropDown = new MyEnum();

    public enum MyEnum
    {
        Overhead,
        Grounded,
        BigBad
    };

    public ParticleSystem explosionParticleBurst;



    // Start is called before the first frame update
    void Start()
    {
        wanderTimer = Random.Range(0.0f,4.9f);
        PlayerPos = GameObject.Find("FPS Player").transform;
        HomePosition = transform.position;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //enemy behaviors are separated based on the public dropdown in the gameobject's script
        if (myDropDown == MyEnum.Overhead)
        {
            //OverheadEnemyAI();
        }

        if (myDropDown == MyEnum.Grounded)
        {
            GroundedEnemyAI();
        }

        if (myDropDown == MyEnum.BigBad)
        {
            BigBadEnemyAI();
        }

        if (HP<=0)
        {
            //explosionParticleBurst.Play(); //play a particle here
            Destroy(gameObject);
        }

    }


    #region functions here

    void GroundedEnemyAI()
    {

        if (attacking)
        {
            agent.speed = 12f; //gotta go fast   
            agent.SetDestination(PlayerPos.position);
            transform.rotation = Quaternion.LookRotation(PlayerPos.position - transform.position);
        }
        else 
        {

            wanderFunction();

        }

    }



    void BigBadEnemyAI()
    {

        if (attacking)
        {
            agent.speed = 12f; //gotta go fast   
            agent.SetDestination(PlayerPos.position);
        }
        else //these guys return to their home when not attacking(asleep)
        {
            agent.SetDestination(HomePosition);

            if ( (transform.position-HomePosition).magnitude<1 )
            {
                //reposition to sleeping angle, WIP
            }

        }

    }





    void OverheadEnemyAI()
    {
        //overhead enemy should move pretty slow, but this function is currently unused for now
        if (attacking)
        {
            agent.speed = 12f; //gotta go fast   
            agent.SetDestination(PlayerPos.position);
        }
        else //wander if not attacking
        {
            wanderTimer += Time.deltaTime;
            if (wanderTimer >= wanderDelay)
            {
                Vector3 destination = new Vector3(transform.position.x + Random.Range(-wanderRange, wanderRange), transform.position.y + Random.Range(-wanderRange, wanderRange), transform.position.z + Random.Range(-wanderRange, wanderRange));

                wanderTimer = 0f;
                agent.SetDestination(destination);
            }
        }

        if (Input.GetMouseButtonDown(2)) //debug test enemy death
        {
            HP = 0;
        }
    }




    void wanderFunction()
    {
        wanderTimer += Time.deltaTime;
        if (wanderTimer >= wanderDelay)
        {
            wanderTimer = 0f;

            //cool code snippet i found that easily picks a random location within a block area
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = wanderRegion.transform.TransformPoint(rndPosWithin * .5f);

            Vector3 destination = rndPosWithin;//new Vector3(transform.position.x + Random.Range(-wanderRange, wanderRange), transform.position.y + Random.Range(-wanderRange, wanderRange), transform.position.z + Random.Range(-wanderRange, wanderRange));
 
            agent.SetDestination(destination);
        }
    }

    #endregion

}

