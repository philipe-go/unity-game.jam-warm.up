using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform target;
    float mouseX, mouseY;
    float mouseYClamp = 85f;
    float rotationSpeed = 1;

    // Added this bit of code to hide cursor from showing in the game
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Changed the transform.position to update with Lerp to make the movement of the camera smoother 
    void LateUpdate() {
        CameraControl();
    }

    void CameraControl() {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -mouseYClamp, mouseYClamp);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        transform.LookAt(player);
    }
}
