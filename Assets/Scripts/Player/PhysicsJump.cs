using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    [SerializeField] private BoxGroundChecker GroundChecker;
    [SerializeField] private Rigidbody RB;

    [SerializeField] private PhysicsMovement PM;
    [SerializeField] private InputController IC;

    private Vector3 startGravity;

    private void Awake()
    {
        startGravity = Physics.gravity;
    }

    public void Jump(string _jumpKeyCode, Vector3 move)
    {
        if (Input.GetAxisRaw(_jumpKeyCode) > 0 && GroundChecker.isGrounded)
        {
            Vector3 jump = new Vector3(move.x * PM.speed * 0.5f, IC._jumpForce * 2f, move.z * PM.speed * 0.5f);
            RB.velocity = new Vector3(RB.velocity.x, 0f, RB.velocity.z);
            RB.velocity = jump;
            StartCoroutine(GravityChange(IC._gravityAnimation, GroundChecker.isGrounded));
        }
    }

    IEnumerator GravityChange(AnimationCurve _gravityScale, bool isGround)
    {
        float duraction = 1f;
        float expiredSeconds = 0f;
        float progress = 0f;

        while(isGround == false || progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duraction;

            Physics.gravity = startGravity + new Vector3(0, -(_gravityScale.Evaluate(progress) * 6f), 0);
            Debug.Log(Physics.gravity);

            yield return null;
        }

        Physics.gravity = startGravity;
    }
}
