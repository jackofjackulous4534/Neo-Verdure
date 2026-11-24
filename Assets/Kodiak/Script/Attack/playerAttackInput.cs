using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeleeAttack))]
public class playerAttackInput : MonoBehaviour
{
    private MeleeAttack melee;
    public GunScript gun;
    public bool hasGun;

    public void Awake()
    {
        melee = GetComponent<MeleeAttack>();
    }
    // melee attacks
    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        melee.Hit();
    }
    // shoot the gun
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started && hasGun)
        {
            gun.StartCoroutine(gun.ShootBullet());
        }
    }
    // reload the gun
    public void Reload(InputAction.CallbackContext ctx)
    {
        if (ctx.started && hasGun)
        {
            gun.StartCoroutine(gun.Reload());
        }
    }
    public void PickUpGun(InputAction.CallbackContext ctx)
    {
        if (ctx.started && !hasGun)
        {
            hasGun = true;
            gun.orbitScript.enabled = true;
        } else if (ctx.started && hasGun)
        {
            hasGun = false;
            gun.orbitScript.enabled = false;
            gun = null;
        }
    }
}
