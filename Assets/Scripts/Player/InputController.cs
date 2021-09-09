using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Axes")]
    [SerializeField] private string axeXPos = "VerticalPos";
    [SerializeField] private string axeYPos = "HorizontalPos";
    [SerializeField] private string axeXNeg = "VerticalNeg";
    [SerializeField] private string axeYNeg = "HorizontalNeg";

    [Header("Mouse")]
    [SerializeField] public float _mouseSensitivity = 100f;
    [SerializeField] public string mouseX = "Mouse X";
    [SerializeField] public string mouseY = "Mouse Y";

    [Header("Jump")]
    [SerializeField] public string _jumpKeycode = "Jump";
    [SerializeField] public float _jumpForce = 1f;
    [SerializeField] public AnimationCurve _gravityAnimation;


    [Space]
    [SerializeField] private PhysicsMovement PM;
    [SerializeField] private PhysicsJump PJ;
    [SerializeField] private Transform CalabrateObject;

    private void Update()
    {
        float xPos = Input.GetAxis(axeXPos);
        float yPos = Input.GetAxis(axeYPos);
        float xNeg = Input.GetAxis(axeXNeg);
        float yNeg = Input.GetAxis(axeYNeg);

        float sumX = xPos + xNeg;
        float sumY = yPos + yNeg;

        Vector3 move =  CalabrateObject.transform.right * sumY + CalabrateObject.transform.forward * sumX;

        PJ.Jump(_jumpKeycode, move);
        PM.Move(move);
    }
}
