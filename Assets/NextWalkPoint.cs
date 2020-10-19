using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWalkPoint : MonoBehaviour
{
    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag!="Floor")
        {
            Debug.Log("Not floor");
            enemyController.isWalkPointSet = false;
            enemyController.walkPoint = new Vector3(0, 0, 0);
            Debug.Log(enemyController.walkPoint);
        }
    }
}
