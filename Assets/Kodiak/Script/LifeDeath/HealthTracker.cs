using System;
using UnityEngine;

public class HealthTracker : MonoBehaviour//, IHasTeam
{
    public float MaxHealth = 5f;
    public float Health = 5f;
    public float MaxArmor = 5f;
    public float Armor = 0f;
    public event Action HealthZero;
    //public PlayerTeams PlayerTeam { get { return _playerTeam; } }
    //[SerializeField] PlayerTeams _playerTeam = PlayerTeams.None;

    public void TakeDamage(float damage)
    {
        if (Armor > 0)
        {
            damage = damage * 0.7f;
            Armor = Mathf.Clamp(Armor - damage, 0, MaxArmor);
        }
        else
        {
            Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
        }

        if (Health <= 0)
        {
            HealthZero?.Invoke();
        }
    }
}
