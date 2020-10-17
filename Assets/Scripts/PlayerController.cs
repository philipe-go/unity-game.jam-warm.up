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
    public Transform itemDropLocation;

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        Movement();
    }

    void Movement() {
        horMovement = Input.GetAxis("Horizontal");
        verMovement = Input.GetAxis("Vertical");
        transform.rotation = transform.rotation * Quaternion.Euler(Vector3.up * rotateSpeed * horMovement * Time.deltaTime);
        transform.position += transform.forward * verMovement * speed * Time.deltaTime;
    }
}
