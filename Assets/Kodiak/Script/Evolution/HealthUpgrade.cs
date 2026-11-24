using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrade : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement PM))
        {
            if (collision.gameObject.TryGetComponent<HealthTracker>(out HealthTracker HT))
            {
                HT.MaxHealth = HT.MaxHealth * 2;
                HT.Health = HT.MaxHealth;
                Destroy(gameObject);
            }
        }
    }
}
