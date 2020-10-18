using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject player;

    public bool[] isFull;
    public GameObject[] slotPlaces;
    public int[] scareID; //Every scare move will have an ID to keep a track of which scare is present in which slot.
    public Transform itemPlacementLocation;


    public GameObject dollPrefab;
    public GameObject skullPrefab;
    public GameObject thirdPrefab;
    public GameObject fourthPrefab;

    // Start is called before the first frame update
    void Start()
    {

        scareID = new int[slotPlaces.Length];
        //player = GameObject.FindGameObjectWithTag("Player");
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectItem(3);
        }
    }

    void SelectItem(int slotNumber)
    {
        GameObject trap;
        switch (scareID[slotNumber])
        {
            case 0:
                Debug.Log("Slot empty");
                break;
            case 1:
                Debug.Log("Place scary item with itemID 1");
                trap = dollPrefab;
                SetTrap(trap);
                break;
            case 2:
                Debug.Log("Place scary item with itemID 2");
                trap = skullPrefab;
                SetTrap(trap);
                break;
            case 3:
                Debug.Log("Place scary item with itemID 3");
                trap = thirdPrefab;
                SetTrap(trap);
                break;
            case 4:
                Debug.Log("Place scary item with itemID 4");
                trap = fourthPrefab;
                SetTrap(trap);
                break;
            default:
                break;
        }

        isFull[slotNumber] = false;
        slotPlaces[slotNumber].GetComponent<Image>().sprite = null;
        scareID[slotNumber] = 0;
    }
    
    public void SetTrap(GameObject trap)
    {
        //Transform trapPos = playerController.itemDropLocation;
        Vector3 trapPos = itemPlacementLocation.position;
        GameObject item = Instantiate(trap, trapPos, Quaternion.identity);
        item.GetComponent<PickUp>().isTrapActive = true;
        //GameObject.Destroy(gameObject);
    }
    
    /*
    public void SetTrap(GameObject trap, int slotID)
    {
        Debug.Log("Inventory wala");
        Instantiate(trap, player.transform.position, Quaternion.identity);
        isFull[slotID] = false;
    }*/
}