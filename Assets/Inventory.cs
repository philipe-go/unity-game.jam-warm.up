using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject player;

    public bool[] isFull;
    public GameObject[] slotPlaces;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    public void SetTrap(GameObject trap, int slotID)
    {
        Debug.Log("Inventory wala");
        Instantiate(trap, player.transform.position, Quaternion.identity);
        isFull[slotID] = false;
    }*/
}