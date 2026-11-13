using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HurtBox : MonoBehaviour
{
    [SerializeField] HealthTracker _healthTracker;
    public void Damage(float damage)
    {
        _healthTracker.TakeDamage(damage);
    }
}
