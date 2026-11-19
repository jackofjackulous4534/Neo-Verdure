using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthTracker : MonoBehaviour
{
    public float Health;
    public event Action HealthZero;

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            HealthZero?.Invoke();
        }
    }
}
