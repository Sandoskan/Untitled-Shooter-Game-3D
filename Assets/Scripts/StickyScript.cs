using System;
using UnityEngine;

public class StickyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float timer = 5f;
    private float _damage;
    private float _blastRadius;

    private void Update()
    {
        if(timer <= 0)
        {
            GetExplode();
        }
        timer -= Time.deltaTime;
    }


    public void GiveStats(float speedProjectile, float damageProjectile, float blastRadius)
    {
        _damage = damageProjectile;
        _blastRadius = blastRadius;
    }

    private void SetSticky(Transform obj)
    {
        _rigidbody.isKinematic = true;
        transform.SetParent(obj);
    }

    public void GetExplode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _blastRadius);

        foreach(Collider nearbyObject in colliders)
        {
            if (nearbyObject.gameObject.tag == "Hitbox")
            {
                if (nearbyObject.TryGetComponent(out HitboxScript hc))
                {
                    Rigidbody rb = hc.GetRigidbody();
                    Debug.Log(rb);
                    rb.AddExplosionForce(10f, transform.position, _blastRadius, 3f, ForceMode.VelocityChange);
                }
<<<<<<< HEAD


=======
>>>>>>> 5dc6031b54344465153a7a96c67c22939695b919
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(_rigidbody.isKinematic == false)
            SetSticky(other.transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, _blastRadius);
    }
}
