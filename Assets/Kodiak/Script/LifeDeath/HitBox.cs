using System;
using UnityEngine;


using NUnit.Framework;
using System.Collections.Generic;
public class HitBox : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    public List<HurtBox> hurtBox = new List<HurtBox>();
    private BoxCollider2D boxCollider;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void HandleCollision(Collider2D otherCollider)
    {
        if (!enabled)
            return;

        if (otherCollider.TryGetComponent<HurtBox>(out HurtBox hb))
        {
            hb.Damage(damage);
            hurtBox.Add(hb);
        }
    }
    void HandleExit(Collider2D otherCollider)
    {
        if (!enabled)
            return;

        if (otherCollider.TryGetComponent<HurtBox>(out HurtBox hb))
        {
            hurtBox.Remove(hb);
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

    public void OnTriggerExit2D(Collider2D collision)
    {
        HandleExit(collision);
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        HandleExit(collision.collider);
    }
}
