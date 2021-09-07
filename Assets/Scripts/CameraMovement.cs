
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private InputController IC;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(new Vector3(xRotation, 0, 0));
    }

    private void Update()
    {
        float mouseX = Input.GetAxis(IC.mouseX) * (IC._mouseSensitivity * 100f) * Time.deltaTime;
        float mouseY = Input.GetAxis(IC.mouseY) * (IC._mouseSensitivity * 100f) * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        yRotation -= mouseX;


        transform.localRotation = Quaternion.Euler(new Vector3(xRotation, -(yRotation), 0));
    }
}
