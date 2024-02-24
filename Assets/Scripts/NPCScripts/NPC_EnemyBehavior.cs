using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_EnemyBehavior : MonoBehaviour
{

    private Camera cam;
    public NavMeshAgent agent;

    public NPC_EnemySight sightScript;

    private Vector3 HomePosition;

    private Quaternion HomeAngle;

    private Vector3 destination;

    private Transform PlayerPos;

    public float wanderDelay = 5f;

    private float wanderTimer = 0f;

    public GameObject wanderRegion;

    public bool returning = false;

    public float movementSpeed = 6f;
    public float angularSpeed = 50f;
    public float acceleration = 1f;

    public float stopDist = 8f;

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
        attacking = false;
        agent.speed = movementSpeed;
        agent.stoppingDistance = stopDist;

        wanderTimer = wanderDelay;
        PlayerPos = GameObject.Find("FPS Player").transform;
        HomePosition = transform.position;
        HomeAngle = transform.localRotation;
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

        if (HP <= 0)
        {
            //explosionParticleBurst.Play(); //play a particle here
            Destroy(gameObject);
        }

    }


    #region functions dropdown here

    void GroundedEnemyAI()
    {

        if (attacking)
        {
            wanderTimer = wanderDelay; //fixes bug when exiting chase?

            agent.speed = 11f; //gotta go fast   
            agent.angularSpeed = 500;
            agent.acceleration = 500;
            agent.stoppingDistance = 8f;

            destination = HomePosition; 
            agent.SetDestination(PlayerPos.position);
            transform.rotation = Quaternion.LookRotation(PlayerPos.position - transform.position);

            returning = true; //just a var to check when the thing returns home from a chase

        }
        else
        {


            agent.stoppingDistance = stopDist;

            if ((transform.position - destination).magnitude < stopDist + 1f) //just to make it return to it's original speed AFTER it gets back home from a chase
            {
                agent.speed = movementSpeed;
                agent.angularSpeed = angularSpeed;
                agent.acceleration = acceleration;
                returning = false;
                //lightObject.SetActive(true);
            }


            if (sightScript.inSightofSelf == false)
            {
                wanderFunction();
            }
            else if (returning == false) //also makes sure it doesnt stop when detecting players on it's way back, just easier that way ;-;
            {
                destination = transform.position;
                agent.SetDestination(destination); //stops here
            }
        }

    }



    void BigBadEnemyAI()
    {

        if (attacking)
        {
           // agent.speed = 12f; //gotta go fast   
            agent.SetDestination(PlayerPos.position);
        }
        else //these guys return to their home when not attacking(asleep)
        {
            agent.SetDestination(HomePosition);

            if ((transform.position - HomePosition).magnitude < 1)
            {
                //reposition to sleeping angle
                transform.localRotation = HomeAngle;
            }

        }

    }



    void wanderFunction()
    {
        if (wanderRegion == null) { Debug.LogError("forgot to set a wander region for" + transform.name); }
        

        if (wanderTimer >= wanderDelay)
        {
            wanderTimer = 0f;

            //cool code snippet i found that easily picks a random location within a block area
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = wanderRegion.transform.TransformPoint(rndPosWithin * .5f);
            destination = rndPosWithin;

            agent.SetDestination(destination);
        }

        if ((transform.position - destination).magnitude < stopDist+1f)
        {
            wanderTimer += Time.deltaTime; //start timer when at destination
        }
    }



    //void OverheadEnemyAI()
    //{
    //    //overhead enemy should move pretty slow, but this function is currently unused for now
    //    if (attacking)
    //    {
    //        agent.speed = 12f; //gotta go fast   
    //        agent.SetDestination(PlayerPos.position);
    //    }
    //    else //wander if not attacking
    //    {
    //        //Vector3 destination = new Vector3(transform.position.x + Random.Range(-wanderRange, wanderRange), transform.position.y + Random.Range(-wanderRange, wanderRange), transform.position.z + Random.Range(-wanderRange, wanderRange));

    //        //if ((transform.position - destination).magnitude < 1)
    //        //{
    //        //    Debug.Log((transform.position - destination).magnitude);
    //        //    wanderTimer += Time.deltaTime; //start timer when at destination
    //        //}

    //        //if (wanderTimer >= wanderDelay)
    //        //{

    //        //    wanderTimer = 0f;
    //        //    agent.SetDestination(destination);
    //        //}
    //    }

    //    if (Input.GetMouseButtonDown(2)) //debug test enemy death
    //    {
    //        HP = 0;
    //    }
    //}
    #endregion

}

