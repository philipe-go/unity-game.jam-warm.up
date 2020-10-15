using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemButton;
    public bool isTrapActive = false;
    // Start is called before the first frame update
    void Start()
    {
        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isTrapActive)
            {
                for (int i = 0; i < inventory.slotPlaces.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slotPlaces[i].transform, false);
                        Destroy(gameObject);
                        break;
                        //Item can be added to the inventory
                    }
                }
            }
        }
    }
}
