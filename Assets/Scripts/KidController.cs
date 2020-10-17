using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour {

    Animator animator;
    CharacterController characterController;
    Vector3 moveDirection;
    float tempValue = 0f;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Trap")) {
            Debug.Log("Trap Collision detected");
            animator.SetTrigger("Run");
        }
    }
}
