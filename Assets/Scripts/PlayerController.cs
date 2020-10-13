using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    float horMovement;
    float verMovement;
    Vector3 direction;
    public float speed = 13f;
    public float rotateSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        
        horMovement = Input.GetAxis("Horizontal");
        Debug.Log(horMovement);
        verMovement = Input.GetAxis("Vertical");
        direction = new Vector3(horMovement, 0, verMovement);
        if (direction!=Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.fixedDeltaTime);
        }
        
        rb.MovePosition(transform.position + (speed *Time.deltaTime*direction));
        
    }
}
