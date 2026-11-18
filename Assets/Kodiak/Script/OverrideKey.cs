using UnityEngine;

public class OverrideKey : MonoBehaviour
{
    [SerializeField] bool pickedUp;
    [SerializeField] OrbitAnchorAndAimAtTarget orbit;
    [SerializeField] PlayerMovement player;
    [SerializeField] DoorScript door;
    void Awake()
    {
        orbit = GetComponent<OrbitAnchorAndAimAtTarget>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickedUp = true;
        }
    }

    void Update()
    {
        if (pickedUp)
        {
            orbit.enabled = true;
            player.slowed = true;

            float playerToDoorDistance = Vector2.Distance(player.transform.position, door.transform.position);
            if (playerToDoorDistance <= 3f)
            {
                door.locked = false;
            }
        } else if (!pickedUp) 
        {
            orbit.enabled = false;
            player.slowed = false;
        }
    }

    public void Drop()
    {
        pickedUp = false;
    }
}
