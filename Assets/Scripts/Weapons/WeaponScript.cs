using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Weapon.WeaponType weaponType;
    [SerializeField] private Weapon.BulletType bulletType;

    [SerializeField] private WeaponsInventory weaponsInventory;
    private Weapon.AmmoType ammoType;

    private int _damagePerBullet;
    private float _range;
    private int _bulletsPerShoot;
    private int _ammoPerShoot;
    private float _scatter;
    private float _rateOfFire;
    private float _projectileSpeed;

    [SerializeField] private Animator anim;

    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject projectileGO;
    [SerializeField] private Camera fpsCam;


    [SerializeField] private GameObject impactEffect;

    [Space]
    [SerializeField] private bool enableTrail = false;
    [SerializeField] private GameObject Trail;
    [SerializeField] private Color trailColor;

    private float tmpTimer;


    private void Start()
    {
        GetComponentsFromData(weaponType);
    }

    private void GetComponentsFromData(Weapon.WeaponType weaponType)
    {
        _damagePerBullet = Weapon.GetDamagePerBullet(weaponType);
        _rateOfFire = Weapon.GetRateOfFire(weaponType);
        _range = Weapon.GetShootRange(weaponType);
        _bulletsPerShoot = Weapon.GetBulletsPerShoot(weaponType);
        _ammoPerShoot = Weapon.GetAmmoPerShoot(weaponType);
        _scatter = Weapon.GetScatter(weaponType);
        _projectileSpeed = Weapon.GetProjectileSpeed(weaponType);
        ammoType = Weapon.GetAmmoType(weaponType);
    }





    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            anim.SetFloat("TmpTimer", tmpTimer);
            if(tmpTimer <= 0)
            {
                if (weaponsInventory.TakenAmmo(ammoType, _ammoPerShoot))
                {
                    Shoot(bulletType);
                    tmpTimer = _rateOfFire;
                }
            }
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(x + y));

        tmpTimer -= Time.deltaTime;
    }



    private void Shoot(Weapon.BulletType bullet)
    {
        anim.SetTrigger("Fire");
        Vector3[] directions = new Vector3[_bulletsPerShoot];
        for (int i = 0; i < directions.Length; i++)
        {
            directions[i] = new Vector3(Random.Range(-_scatter, _scatter), Random.Range(-_scatter, _scatter), Random.Range(-_scatter, _scatter));
        }

        if (bullet == Weapon.BulletType.Hitscan)
        {

            RaycastHit hitInfo;
            for (int i = 0; i < directions.Length; i++)
            {
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + directions[i], out hitInfo, _range))
                {
                    if (enableTrail == true)
                    {
                        GameObject trailGO = Instantiate(Trail);
                        LineRenderer trailLR = trailGO.GetComponent<LineRenderer>();
                        trailLR.startColor = trailColor;
                        trailLR.endColor = trailColor;
                        trailLR.SetPositions(new Vector3[] { firePoint.position, hitInfo.point });
                        Destroy(trailGO, 2f);
                    }
                    GameObject impactGo = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(impactGo, 2f);
                }
            }

        }
        
        if(bullet == Weapon.BulletType.Projectile)
        {
            GameObject pipe = Instantiate(projectileGO, firePoint.position, Quaternion.LookRotation(new Vector3(fpsCam.transform.forward.x, 0f, fpsCam.transform.forward.z)));
            pipe.GetComponent<StickyScript>().GiveStats(_projectileSpeed, _damagePerBullet, _range);
            pipe.GetComponent<Rigidbody>().velocity = transform.forward * _projectileSpeed * 20f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(firePoint.position, Vector3.one * 0.25f);
    }

    private void OnEnable()
    {
        tmpTimer = 0.5f;
    }
}
