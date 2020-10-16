using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetectionLocation : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> trapsInRange = new List<GameObject>(); //took a random size of the array. The size of the array should be more than total number of traps in the level.
    public GameObject deactivateTrapUI;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //trapsInrange.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        DeactivateTrap();
    }

    void DeactivateTrap()
    {
        if (trapsInRange.Count != 0)            //to deactivate the trap
        {
            deactivateTrapUI.SetActive(true);
            float nearestTrapDistance = Vector3.Distance(player.transform.position, trapsInRange[0].transform.position);
            int nearestTrapIndex = 0;
            for (int i = 0; i < trapsInRange.Count; i++)
            {
                float currentTrapDistance = Vector3.Distance(player.transform.position, trapsInRange[i].transform.position);
                if (currentTrapDistance < nearestTrapDistance)
                {
                    nearestTrapDistance = currentTrapDistance;
                    nearestTrapIndex = i;
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                trapsInRange[nearestTrapIndex].GetComponent<PickUp>().isTrapActive = false;
                trapsInRange.RemoveAt(nearestTrapIndex);
            }
        }
        else
        {
            deactivateTrapUI.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            bool isTrapActive = other.gameObject.GetComponent<PickUp>().isTrapActive;
            //Debug.Log("triggered");
            if (isTrapActive)
            {
                bool isInList = false;
                if (trapsInRange.Count != 0)
                {
                    for (int i = 0; i < trapsInRange.Count; i++)
                    {
                        //Debug.Log("inside For Loop");
                        if (trapsInRange[i] == other.gameObject)
                        {
                            isInList = true;
                            //Don't add to list
                        }

                    }
                }
                else
                {
                    //Debug.Log("List is empty");
                    isInList = false;
                }
                if (!isInList)
                {
                    //Debug.Log("added");
                    //add to list
                    trapsInRange.Add(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trap"))       //check the tag
        {
            for (int i = 0; i < trapsInRange.Count; i++)        //Checking if the item was in the trapsInRange list
            {
                //Debug.Log("inside For Loop");
                if (trapsInRange[i] == other.gameObject)
                {
                    //The item was in the list
                    //Remove the item from the list
                    trapsInRange.RemoveAt(i);
                }

            }
        }
    }
}