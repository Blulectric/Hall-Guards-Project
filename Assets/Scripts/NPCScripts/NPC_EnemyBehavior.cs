using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_EnemyBehavior : MonoBehaviour
{
    //liz
    private Camera cam;
    public NavMeshAgent agent;

    public NPC_EnemySight sightScript;

    private Vector3 HomePosition;

    private Quaternion HomeAngle;

    private Vector3 destination;

    private GameObject Player;

    private PLYR_Health playerHP;

    public Transform Robot;

    public float wanderDelay = 5f;
    private float wanderTimer = 0f;

    public GameObject wanderRegion;

    public float shootDelay = 2f;
    private float shootTimer = 0f;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;

    public float startAttackFromRadius = 0f;
    private bool attackRadiCheck = false;

    public bool returning = false;

    public float movementSpeed = 6f;
    public float angularSpeed = 50f;
    public float acceleration = 1f;

    public float stopDist = 8f;

    public static bool attacking = false; // all enemies will attack if this is true

    public int HP = 100;

    [SerializeField]
    private ModeSelector modes;

    private Animator animator;


    public MyEnum myDropDown = new MyEnum();

    public enum MyEnum
    {
        Overhead,
        Grounded,
        BigBad
    };

    public GameObject explosionParticleBurst;

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        agent.speed = movementSpeed;
        agent.stoppingDistance = stopDist;

        wanderTimer = wanderDelay;
        Player = GameObject.Find("FPS Player");
        playerHP = Player.GetComponent<PLYR_Health>();
        HomePosition = transform.position;
        HomeAngle = transform.localRotation;
        cam = Camera.main;

        animator = GetComponent<Animator>();

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
            DestroyEnemy();
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
            agent.SetDestination(Player.transform.position);
            transform.rotation = Quaternion.LookRotation(Player.transform.position - transform.position);

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

        if (agent.velocity.magnitude == 0)
        {
            animator.SetBool("isWalking", false);
        } else {
            animator.SetBool("isWalking", true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (myDropDown == MyEnum.BigBad)
        {
            if (WLD_RunGunTrigger.GENOCIDE == false && attacking)
            {
                playerHP.takeDamage(100);
            }
            //else if (WLD_RunGunTrigger.GENOCIDE == true)
            //{

            //}


        }
    }

    void BigBadEnemyAI()
    {
        if (!modes.invisMode)
        {
            if (WLD_RunGunTrigger.GENOCIDE == true)
            {
                agent.stoppingDistance = 20f;
                //radius = 3f;
                shootTimer += Time.deltaTime;
                if (shootTimer >= shootDelay)
                {
                    if((transform.position - Player.transform.position).magnitude < startAttackFromRadius)
                    {
                        shootTimer = 0f;
                        GameObject bullet;
                        bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
                        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.transform.up * 30, ForceMode.VelocityChange);
                    }
                }
            }
            if (attacking)
            {

                if (startAttackFromRadius != 0) // some enemies later on will only activate on radius, if the startAttackFromRadius is set manually it will activate them based on startAttackFromRadius distance
                {
                    if ((transform.position - Player.transform.position).magnitude < startAttackFromRadius)
                    {
                        attackRadiCheck = true;
                    }
                }
                else
                {
                    attackRadiCheck = true;
                }

                if (attackRadiCheck == true)
                {
                    animator.SetBool("isRunning", true);
                    agent.SetDestination(Player.transform.position);
                    transform.rotation = Quaternion.LookRotation(Player.transform.position - transform.position);
                } else 
                {
                    animator.SetBool("isRunning", false);
                }
            }
            else //these guys return to their home when not attacking(asleep)
            {
                
                animator.SetBool("isRunning", false);

                agent.SetDestination(HomePosition);

                if ((transform.position - HomePosition).magnitude < 1)
                {
                    //reposition to sleeping angle
                    transform.localRotation = HomeAngle;
                }

            }

        }

    }



    void wanderFunction()
    {
        if (wanderRegion == null) { Debug.LogError("forgot to set a wander region for" + transform.name); }

        if (wanderTimer >= wanderDelay)
        {
            wanderTimer = 0f;

            //animator.SetBool("isWalking", true);

            //cool code snippet i found that easily picks a random location within a block area
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = wanderRegion.transform.TransformPoint(rndPosWithin * .5f);
            destination = rndPosWithin;

            //animator.SetBool("isWalking", true);

            agent.SetDestination(destination);
        } 

        if ((transform.position - destination).magnitude < stopDist + 1f)
        {
            wanderTimer += Time.deltaTime; //start timer when at destination
        }
    }

    private void DestroyEnemy()
    {

        GameObject deathEffect = Instantiate(explosionParticleBurst, Robot.position, Robot.rotation);
        Destroy(gameObject);
        //Destroy(deathEffect, 2.5f);


        /*if (!explosionParticleBurst.IsAlive())
        {
        }*/
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

