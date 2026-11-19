using TMPro;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    [SerializeField] HealthTracker player;
    [SerializeField] TextMeshProUGUI InfoText;
    [SerializeField] GameObject InfoBox;
    public void PickUp()
    {
        player.Health = player.Health * 2f;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit" + collision);
        if (collision.gameObject.TryGetComponent<HealthTracker>(out HealthTracker HT))
        {
            player = HT;
            Debug.Log("attached player health");
            PickUp();
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        float playerDistance = Vector2.Distance(transform.position, player.transform.position);
        if (playerDistance <= 2f)
        {
            InfoBox.SetActive(true);
            InfoText.text = "Multiplies you health by 2";
        }
        else
        {
            InfoBox.SetActive(false);
        }
    }
}
