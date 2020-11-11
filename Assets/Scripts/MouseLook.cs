using UnityEngine;

public class MouseLook : MonoBehaviour{
    private float mouseX;
    private float mouseY;
    private float xRotation;
    public float mouseSensitivity = 100;
    public Transform playerBody;

    private float rayDistance = 10f;
    private Ray ray;
    private RaycastHit hit;

    public Transform gunBarrel;

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update(){
        if (Input.GetButtonDown("Fire1"))
            Shoot();

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void Shoot(){
        ray = new Ray(gunBarrel.position, transform.forward);

        Debug.DrawRay(gunBarrel.position, transform.forward, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance)){
            print("Shit hit");
        }
    }
}