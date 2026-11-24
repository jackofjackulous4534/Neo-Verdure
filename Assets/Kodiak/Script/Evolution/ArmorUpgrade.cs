using UnityEngine;

public class ArmorUpgrade : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement PM))
        {
            if (collision.gameObject.TryGetComponent<HealthTracker>(out HealthTracker HT))
            {
                HT.MaxArmor = HT.MaxArmor * 2;
                HT.Armor = HT.MaxArmor;
                Destroy(gameObject);
            }
        }
    }
}
