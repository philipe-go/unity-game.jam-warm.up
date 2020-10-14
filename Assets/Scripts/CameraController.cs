using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    [SerializeField] Vector3 offset;
    [Range(1,11)][SerializeField] int moveSpeed;
    

    void Start()
    {
        moveSpeed = 9;
        transform.position = target.position;
        transform.LookAt(player.transform);
    }


    //Changed the transform.position to update with Lerp to make the movement of the camera smoother 
    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
    }
}
