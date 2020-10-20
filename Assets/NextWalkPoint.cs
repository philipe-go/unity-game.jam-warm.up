using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NextWalkPoint : MonoBehaviour
{
    public EnemyController enemyController;
    NavMeshAgent navAgent;
    NavMeshPath navPath;
    Vector3 newPos;
    //bool validWaypoint;
    //bool coroutineON;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        //navPath = new NavMeshPath();
        //coroutineON = false;
        // enemyController = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Kid")
        {
            Debug.Log("Kid detected");
            if (!coroutineON) StartCoroutine(SetNewPathCoroutine(2.0f));
            // enemyController.walkPoint = this.transform.position;
            // Debug.Log(enemyController.walkPoint);
        }
    }
    
    void WayPointSetter()
    {
        //Calculate a random point on the map
        float randomZ = Random.Range(-enemyController.walkPointRange, enemyController.walkPointRange);
        float randomX = Random.Range(-enemyController.walkPointRange, enemyController.walkPointRange);
        newPos = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
    }

    IEnumerator SetNewPathCoroutine(float timer)
    {
        coroutineON = true;
        WayPointSetter();
        validWaypoint = navAgent.CalculatePath(newPos,navPath);
        while(validWaypoint) 
        {
            yield return new WaitForSeconds(0.01f);
            WayPointSetter();
            validWaypoint = navAgent.CalculatePath(newPos,navPath);
        }
        this.transform.position = newPos;
        enemyController.navMeshAgent.SetDestination(newPos);
        yield return new WaitForSeconds(timer);
        coroutineON = false;
    }
    */
}
