using UnityEngine;

[RequireComponent(typeof(HealthTracker))]

public class DestroyOnDeath : MonoBehaviour
{
    private HealthTracker _HT;

    public void Awake()
    {
        _HT = GetComponent<HealthTracker>();
        _HT.HealthZero += Die;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
