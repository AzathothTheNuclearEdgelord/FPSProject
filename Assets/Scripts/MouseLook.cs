using System;
using UnityEngine;

public class MouseLook : MonoBehaviour{
    private float mouseX;
    private float mouseY;

    private float xRotation;
    
    public float mouseSensitivity = 100;
    public Transform playerBody;

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update(){
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}