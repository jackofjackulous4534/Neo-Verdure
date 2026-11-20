using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpgrade : MonoBehaviour
{
    [SerializeField] HitBox hitBox;
    [SerializeField] PlayerMovement player;
    [SerializeField] UpgradesSpawner spawner;
    [SerializeField] TextMeshProUGUI InfoText;
    [SerializeField] Image InfoBox;
    [SerializeField] float playerDistance;
    public void PickUp()
    {
        //hitBox._damage = hitBox._damage * 2f; BRO WTF YOU DOIN ;-;   D:<
        spawner.currentUpgrades -= 1f;
    }
    public void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        hitBox = player.GetComponentInChildren<HitBox>();
        spawner = FindAnyObjectByType<UpgradesSpawner>();
        spawner.currentUpgrades += 1f;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit" + collision);
        if (collision.gameObject.TryGetComponent(out HitBox HB))
        {
            Debug.Log("attached " + HB);
            PickUp();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        playerDistance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(player.transform.position);
        if (playerDistance <= 3f)
        {
            InfoBox.enabled = true;
            InfoText.text = "Multiplies your damage by 2";
        }
        else
        {
            InfoBox.enabled = false;
            InfoText.text = "";
        }

        if (spawner.currentUpgrades <= 1)
        {
            Destroy(gameObject);
        }
    }
}