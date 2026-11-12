using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeleeAttack))]
public class playerAttackInput : MonoBehaviour
{
    private MeleeAttack melee;

    public void Attack(InputAction.CallbackContext ctxS)
    {
        melee.Hit();
    }
}
