using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    public NavMeshPath navPath;
    public Animator animator;
    public bool isScared = false;

    public Transform sanityRestorePoint;

    //--------------------Patrolling Part--------------------------

    public LayerMask groundLayer;
    public Vector3 walkPoint;
    public bool isWalkPointSet;
    public float walkPointRange;
    public bool isIdle = false;

    //for debugging purpose
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navPath = new NavMeshPath();
        animator = transform.GetComponentInChildren<Animator>();
        navMeshAgent.SetDestination(cube.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isScared)
        {
            ScaredState();
        }
        else
        {
            if (isIdle)
            {

            }
            else
            {
                NormalState();
                //Patrolling();
            }
        }

    }

    void NormalState()
    {
        //Idle condition (Suppose if the kid is doing some task)

        navMeshAgent.speed = 7f;
        navMeshAgent.acceleration = 25f;
        Walk();
    }
    void ScaredState()
    {
        //Running
        Run();
        navMeshAgent.SetDestination(sanityRestorePoint.position);
        Vector3 distanceToSanityRestorePoint = transform.position - sanityRestorePoint.position;
        if (distanceToSanityRestorePoint.magnitude < 5f)
        {
            //reached Sanity Restore Location.
            //Restore his sanity
            isScared = false;
            navMeshAgent.SetDestination(cube.transform.position);
        }
    }
    void Idle()
    {
        navMeshAgent.speed = 0f;
        navMeshAgent.acceleration = 0f;
        animator.SetBool("isIdle", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
    }
    void Walk()
    {
        navMeshAgent.speed = 10f;
        navMeshAgent.acceleration = 20f;
        animator.SetBool("isIdle", false);
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
    }
    void Run()
    {
        navMeshAgent.speed = 18f;
        navMeshAgent.acceleration = 30f;
        animator.SetBool("isIdle", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", true);
    }


    // void Patrolling()
    // {
    //     if (!isWalkPointSet)
    //     {
    //         SearchWalkPoint();
    //     }
    //     else
    //     {
    //         navMeshAgent.SetDestination(walkPoint);
    //         cube.transform.position = walkPoint;
    //     }
    //     Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //     if (distanceToWalkPoint.magnitude < 5f)
    //     {
    //         isWalkPointSet = false;
    //     }
    //     navMeshAgent.SetDestination(cube.transform.position);
    // }

    // void SearchWalkPoint()
    // {
    //     //Calculate a random point on the map
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //     if (Physics.Raycast(walkPoint, -transform.up, groundLayer))
    //     {
    //         isWalkPointSet = true;
    //     }
    // }
}
