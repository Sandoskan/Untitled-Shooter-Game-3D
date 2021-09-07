using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    [SerializeField] private BoxGroundChecker GroundChecker;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private InputController IC;

    public void Jump(string _jumpKeyCode)
    {
        if (Input.GetAxisRaw(_jumpKeyCode) > 0 && GroundChecker.isGrounded)
        {
            Vector3 jump = new Vector3(RB.velocity.x, IC._jumpForce * 2f, RB.velocity.z);
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

        Vector3 startGravity = Physics.gravity;

        while(progress < 1 || isGround == false)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duraction;

            Physics.gravity = startGravity + new Vector3(0, -(_gravityScale.Evaluate(progress) * 6f), 0);

            yield return null;
        }

        Physics.gravity = startGravity;
    }
}
