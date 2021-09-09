using UnityEngine;

public class HitscanShootScript : MonoBehaviour
{
    [SerializeField] private float _damagePerBullet = 10f;
    [SerializeField] private float range = 100f;

    [SerializeField] private Camera fpsCam;
    [SerializeField] private GameObject impactEffect;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            GameObject impactGo = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGo, 2f);
        }
    }

}
