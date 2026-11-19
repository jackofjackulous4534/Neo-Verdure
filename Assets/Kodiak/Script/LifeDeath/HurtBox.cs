using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HurtBox : MonoBehaviour, IHasTeam
{
    public PlayerTeams PlayerTeam { get { return _playerTeam; } }
    [SerializeField] PlayerTeams _playerTeam = PlayerTeams.None;

    [SerializeField] HealthTracker _healthTracker;
    public void Damage(float damage)
    {
        _healthTracker.TakeDamage(damage);
    }
}
