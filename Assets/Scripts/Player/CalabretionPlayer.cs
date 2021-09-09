using UnityEngine;

public class CalabretionPlayer : MonoBehaviour
{
    [SerializeField] private Transform Camera;

    private void Update()
    {
        SetRotateFromCamera();
    }

    void SetRotateFromCamera()
    {
        Vector3 rotate = new Vector3(transform.rotation.x, Camera.eulerAngles.y, Camera.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotate);
    }
}
