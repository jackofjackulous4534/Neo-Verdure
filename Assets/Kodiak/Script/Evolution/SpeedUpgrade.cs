using UnityEngine;

public class SpeedUpgrade : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement PM))
        {
            PM.speedMulti = PM.speedMulti += 0.5f;
            Destroy(gameObject);
        }
    }
}
