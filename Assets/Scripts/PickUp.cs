using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Inventory inventory;
    public Sprite itemIcon;
    public bool isTrapActive = false;
    public int scareID;  //Every scare move will have an ID to keep a track of which scare is present in which slot.
    
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        gameObject.GetComponent<Outline>().enabled = isTrapActive ? false : true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isTrapActive)
            {
                for (int i = 0; i < inventory.slotPlaces.Length; i++)
                {
                    if (inventory.isFull[i] == false)  //Item can be added to the inventory
                    {
                        inventory.isFull[i] = true;
                        inventory.slotPlaces[i].GetComponent<Image>().sprite = itemIcon;
                        inventory.scareID[i] = scareID;
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }

}