using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpgrade : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement Player))
        {
            if (collision.gameObject.TryGetComponent<MeleeAttack>(out MeleeAttack MA))
            {
                MA.damage = MA.damage * 2f;
                Destroy(gameObject);
            }
        }
    }
}