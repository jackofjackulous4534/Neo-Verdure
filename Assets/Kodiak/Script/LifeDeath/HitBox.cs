using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour, IHasTeam
{
    public PlayerTeams PlayerTeam { get { return _playerTeam; } }
    [SerializeField] PlayerTeams _playerTeam = PlayerTeams.None;

    [SerializeField] float _damage = 1f;
    private HashSet<HurtBox> _hurtBoxesInField = new HashSet<HurtBox>();
    private HashSet<HurtBox> _hurtBoxesHit = new HashSet<HurtBox>();
    private bool _isAttacking = false;

    void HandleCollisionEnter(Collider2D otherCollider)
    {
        if (otherCollider.TryGetComponent<HurtBox>(out HurtBox hb))
        {
            _hurtBoxesInField.Add(hb);
            if (_isAttacking && !_hurtBoxesHit.Contains(hb)) 
            {
                DamageHurtBox(hb);
            }
        }
    }
    void HandleCollisionExit(Collider2D otherCollider)
    {
        if (otherCollider.TryGetComponent<HurtBox>(out HurtBox hb))
        {
            _hurtBoxesInField.Remove(hb);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) => HandleCollisionEnter(collision);
    public void OnCollisionEnter2D(Collision2D collision) => HandleCollisionEnter(collision.collider);
    public void OnTriggerExit2D(Collider2D collision) => HandleCollisionExit(collision);
    public void OnCollisionExit2D(Collision2D collision) => HandleCollisionExit(collision.collider);

    public void StartAttack()
    {
        foreach (HurtBox hb in _hurtBoxesInField.ToList()) //BANDAID FIX LOL
        {
            DamageHurtBox(hb);
        }
        _isAttacking = true;
    }
    public void EndAttack()
    {
        _hurtBoxesHit.Clear();
        _isAttacking = false;
    }

    private void DamageHurtBox(HurtBox hurtBox)
    {
        if (PlayerTeam == hurtBox.PlayerTeam && PlayerTeam != PlayerTeams.None && hurtBox.PlayerTeam != PlayerTeams.None) 
        { 
            //Debug.Log("Skipped");  
            return; 
        }
        hurtBox.Damage(_damage);
        _hurtBoxesHit.Add(hurtBox);
    }
}
