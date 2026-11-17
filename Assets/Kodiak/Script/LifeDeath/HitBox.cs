using System;
using UnityEngine;


using NUnit.Framework;
using System.Collections.Generic;
public class HitBox : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    public List<HurtBox> hurtBoxes = new List<HurtBox>();
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
