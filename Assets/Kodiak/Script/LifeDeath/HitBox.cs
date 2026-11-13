using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    void HandleCollision(Collider2D otherCollider)
    {
        if (!enabled)
            return;

        if (otherCollider.TryGetComponent<HurtBox>(out HurtBox hb))
        {
            hb.Damage(damage);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.collider);
    }
}
