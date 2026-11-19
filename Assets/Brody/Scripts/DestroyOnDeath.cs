using UnityEngine;

[RequireComponent(typeof(HealthTracker))]

public class DestroyOnDeath : MonoBehaviour
{
    private HealthTracker _HT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        _HT = GetComponent<HealthTracker>();
        _HT.HealthZero += Die;
    }
    
    public void Die()
    {
       // Destroy
    }
}
