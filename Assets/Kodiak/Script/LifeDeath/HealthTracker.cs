using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public float Health;

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
