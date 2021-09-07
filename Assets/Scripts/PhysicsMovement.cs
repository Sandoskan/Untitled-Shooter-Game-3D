using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody RB;
    [SerializeField] private SurfaceSlider _surfaceSlider;

    public void Move(Vector3 move)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(move);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);


        RB.MovePosition(RB.position + offset);
    }
}
