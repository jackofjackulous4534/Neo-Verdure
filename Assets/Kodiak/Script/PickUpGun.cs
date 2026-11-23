using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(playerAttackInput))]
[RequireComponent(typeof(CircleCollider2D))]
public class PickUpGun : MonoBehaviour
{
    private playerAttackInput playerA;
    void Awake()
    {
        playerA = GetComponent<playerAttackInput>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out GunScript GS))
        {
            playerA.gun = GS.GetComponent<GunScript>();
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out GunScript GS) && playerA.hasGun == false)
        {
            playerA.gun = null;
        }
    }
}
