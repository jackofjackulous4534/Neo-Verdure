using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] int MaxAmmo = 25;
    [SerializeField] int Ammo;
    [SerializeField] float fireRate = 0.4f;
    [SerializeField] float reloadSpeed = 1f;
    [SerializeField] bool canShoot;
    [SerializeField] GameObject Bullet;
    public OrbitAnchorAndAimAtTarget orbitScript;
    void Awake()
    {
        orbitScript = GetComponent<OrbitAnchorAndAimAtTarget>();
    }
    public IEnumerator ShootBullet()
    {
        if (Ammo > 0 && canShoot)
        {
            canShoot = false;
            Ammo -= 1;
            Instantiate(Bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }
    }

    public IEnumerator Reload()
    {
        if (Ammo < MaxAmmo)
        {
            yield return new WaitForSeconds(reloadSpeed);
            Ammo = MaxAmmo;
        }
    }
}
