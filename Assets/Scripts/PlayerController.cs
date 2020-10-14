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
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        // rend.material.SetFloat("_Mode", 10f);
    }

    private void Update() {
        InvisiblePower();
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

    void InvisiblePower() {
        if (Input.GetKeyDown(KeyCode.F)) {
            GetComponentInChildren<BoxCollider>().isTrigger = true;
            rend.material = matInvisible;
        }

        if (Input.GetKeyUp(KeyCode.F)) {
            GetComponentInChildren<BoxCollider>().isTrigger = false;
            rend.material = matNormal;
        }
    }
}
