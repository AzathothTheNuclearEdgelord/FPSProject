using UnityEngine;

public class MouseLook : MonoBehaviour{
    private float mouseX;
    private float mouseY;
    private float xRotation;
    public float mouseSensitivity = 100;
    public Transform playerBody;

    private float rayDistance = 20f;
    private Ray ray;
    private RaycastHit hit;

    public Transform gunBarrel;

    public GameObject bulletTest;

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update(){
        Debug.DrawRay(gunBarrel.position, transform.forward, Color.red);
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
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, rayDistance)){
            Instantiate(bulletTest, hit.collider.transform);
            if (hit.collider.CompareTag("EvilCube")){
                Destroy(hit.collider.gameObject);
                print("Hit and eliminated the heretic!");
            }
        }
    }
}