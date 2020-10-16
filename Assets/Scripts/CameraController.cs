using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform target;
    float mouseX, mouseY;
    float mouseYClamp = 85f;
    float rotationSpeed = 1;

<<<<<<< HEAD
    // Added this bit of code to hide cursor from showing in the game
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
=======
    void Start()
    {
        moveSpeed = 9;
        transform.position = target.position;
        transform.LookAt(player.transform);
>>>>>>> origin/Inventory
    }

    //Changed the transform.position to update with Lerp to make the movement of the camera smoother 
<<<<<<< HEAD
    void LateUpdate() {
        CameraControl();
    }

    void CameraControl() {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -mouseYClamp, mouseYClamp);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        transform.LookAt(player);
=======
    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
>>>>>>> origin/Inventory
    }
}
