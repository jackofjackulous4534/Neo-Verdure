using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeleeAttack))]
public class playerAttackInput : MonoBehaviour
{
    private MeleeAttack melee;

    public void Awake()
    {
        melee = GetComponent<MeleeAttack>();
    }
    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        melee.Hit();
    }
}
