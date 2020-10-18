using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = transform.GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Trap"))       //checking it it's a trap or not
        {
            GameObject trap = other.gameObject;
            if(trap.GetComponent<PickUp>().isTrapActive == true)        //checking if the trap is active or not
            {
                Debug.Log("Yes trap is active");
                //raycast to the trap to see if kid can actually see it or not.
                RaycastHit raycastHit;
                Vector3 direction = trap.transform.position - this.transform.position;          //direction vector from player to trap
                if (Physics.Raycast(transform.position, direction, out raycastHit))             //checking if the raycast hit something or not
                {
                    Debug.Log("Raycast is hitting an object");
                    Debug.DrawRay(transform.position, direction, Color.red);
                    if (raycastHit.transform.gameObject.CompareTag("Trap"))         //checking if the object that raycast hitted is a trap or if there's another object covering the obstacle
                    {
                        Debug.Log("It has hit a trap");
                        enemyController.isScared = true;
                    }
                    else
                    {
                        Debug.Log("did not hit trap");
                        enemyController.isScared = false;
                    }
                }
                

                
            }
        }
        if (other.CompareTag("Player"))
        {
            //Scare the kiddo if ghost is not invisible(i.e if F is not pressed)
        }
    }
}
