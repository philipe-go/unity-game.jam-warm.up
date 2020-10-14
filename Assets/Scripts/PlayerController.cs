using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    float horMovement;
    float verMovement;
    public float speed = 13f;
    public float rotateSpeed = 30f;
    SkinnedMeshRenderer rend;
    public Material matInvisible;
    public Material matNormal;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        InvisiblePower();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        horMovement = Input.GetAxis("Horizontal");
        verMovement = Input.GetAxis("Vertical");

        //if (direction != Vector3.zero)
        //{
        //    //rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.fixedDeltaTime);
        //}

        rb.rotation = transform.rotation * Quaternion.Euler(Vector3.up * rotateSpeed * horMovement * Time.deltaTime);
        rb.position += transform.forward * verMovement * speed * Time.deltaTime;
    }

    void InvisiblePower()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<BoxCollider>().isTrigger = true;
            rend.material = matInvisible;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            GetComponent<BoxCollider>().isTrigger = false;
            rend.material = matNormal;
        }
    }
}
