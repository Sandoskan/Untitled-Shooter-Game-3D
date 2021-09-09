using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;


    public Vector3 Project(Vector3 forward)
    {
        return forward - Vector3.Dot(forward, _normal) * _normal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
            _normal = collision.contacts[0].normal;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            _normal = collision.contacts[0].normal;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.position));
    }
}
