using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Inventory inventory;
    public int slotID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[slotID] = false;
        }
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<ScaresManager>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
