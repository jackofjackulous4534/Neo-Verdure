using UnityEngine;

public class GunUpgrade : MonoBehaviour
{
    [SerializeField] GameObject Gun;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement Player))
        {
            Instantiate(Gun, new Vector2(transform.position.x, transform.position.y + 2f), transform.rotation);
            Destroy(gameObject);
        }
    }
}
