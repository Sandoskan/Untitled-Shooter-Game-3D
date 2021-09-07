using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxGroundChecker : MonoBehaviour
{
    private Collider colider;
    [SerializeField] public bool isGrounded;
    [SerializeField] private LayerMask ground;

    private void Awake()
    {
        colider = GetComponent<Collider>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckBox(transform.position, colider.bounds.extents, Quaternion.identity, ground);
    }
}
