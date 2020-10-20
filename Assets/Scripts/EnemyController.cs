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

    //public LayerMask groundLayer;
    public Vector3 nextWalkPoint;
    public bool isNextWalkPointSet;
    //public float walkPointRange;
    public bool isIdle = false;
    public Transform[] walkPoints;
    public GameObject walkpointCollection;
    public int nextWalkPointIndex=0;

    //for debugging purpose
    //public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navPath = new NavMeshPath();
        animator = transform.GetComponentInChildren<Animator>();
        //navMeshAgent.SetDestination(cube.transform.position);
        SetWalkPoints();
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
                Patrolling();
            }
        }

    }

    void SetWalkPoints()
    {
        walkPoints = new Transform[walkpointCollection.transform.childCount];
        for (int i = 0; i < walkPoints.Length; i++)
        {
            walkPoints[i] = walkpointCollection.transform.GetChild(i);
        }
    }
    void NormalState()
    {
        //Idle condition (Suppose if the kid is doing some task)
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
            //navMeshAgent.SetDestination(cube.transform.position);
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


     void Patrolling()
     {
         if (!isNextWalkPointSet)
         {
             SearchWalkPoint();
         }
         else
         {
             navMeshAgent.SetDestination(nextWalkPoint);
             //cube.transform.position = nextWalkPoint;
         }
         Vector3 distanceToWalkPoint = transform.position - nextWalkPoint;

         if (distanceToWalkPoint.magnitude < 5f)
         {
             isNextWalkPointSet = false;
         }
         
     }

     void SearchWalkPoint()
     {
        nextWalkPointIndex = Random.Range(0, walkPoints.Length);
        nextWalkPoint = walkPoints[nextWalkPointIndex].position;
        navMeshAgent.SetDestination(nextWalkPoint);
        isNextWalkPointSet = true;
     }
}
