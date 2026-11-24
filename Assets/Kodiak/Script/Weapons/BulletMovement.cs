using UnityEngine;

public class BulletMovement : MonoBehaviour, IHasTeam
{
    [SerializeField] float _damage;
    [SerializeField] float _bulletSpeed;
    [SerializeField] float _bulletLife = 5f;
    private float _startOfLife;
    public PlayerTeams PlayerTeam { get { return _playerTeam; } }
    [SerializeField] PlayerTeams _playerTeam = PlayerTeams.None;
    void Awake()
    {
        _startOfLife = Time.time;
        // Debug.Log("Spawned");
    }
    public void FixedUpdate()
    {
        if (CustomUtilities.HasTimeElapsed(_startOfLife, _bulletLife))
        {
            Destroy(gameObject);
        }
        RaycastHit2D hitData = Physics2D.Raycast(transform.position, transform.rotation.eulerAngles, _bulletSpeed * Time.fixedDeltaTime);

        if (hitData)
        {
            if (hitData.collider.TryGetComponent(out HurtBox HB))
            {
                if (PlayerTeam == HB.PlayerTeam && PlayerTeam != PlayerTeams.None && HB.PlayerTeam != PlayerTeams.None)
                {
                    //Debug.Log("Skipped");
                    return;
                } else
                {
                    HB.Damage(_damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
