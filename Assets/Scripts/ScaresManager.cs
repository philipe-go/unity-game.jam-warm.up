using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaresManager : MonoBehaviour
{
    public GameObject inactiveItemTrap;
    public GameObject activeItemTrap;

    PlayerController playerController;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void SpawnDroppedItem()
    {
        //Transform trapPos = playerController.itemDropLocation;
        Transform trapPos = player.transform;
        GameObject item = Instantiate(inactiveItemTrap, trapPos.position, Quaternion.identity);
        item.GetComponent<PickUp>().isTrapActive = false;
        //Instantiate(inactiveItemTrap, player.transform.position, Quaternion.identity);
    }

    public void SetTrap()
    {
        //Transform trapPos = playerController.itemDropLocation;
        Transform trapPos = player.transform;
        GameObject item = Instantiate(activeItemTrap, trapPos.position, Quaternion.identity);
        item.GetComponent<PickUp>().isTrapActive = true;
        item.GetComponent<Outline>().enabled = false;
        GameObject.Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}