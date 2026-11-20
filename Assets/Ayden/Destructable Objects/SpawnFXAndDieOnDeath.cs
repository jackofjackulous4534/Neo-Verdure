using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnFXOnDeath : MonoBehaviour
{
    private HealthTracker _HT;
    [SerializeField] ParticleSystem _deathParticleVFX;
    [SerializeField] AudioClip _deathSFX;
    public void Awake()
    {
        _HT = GetComponent<HealthTracker>();
        _HT.HealthZero += Die;
    }
    public void Die()
    {
        if (_deathParticleVFX)
        {
            ParticleSystem pfx = Instantiate(_deathParticleVFX, transform.position, Quaternion.identity);
            Debug.Log(pfx.main.duration);
            Destroy(pfx.gameObject, pfx.main.duration);
        }
        Destroy(gameObject);
    }
}
