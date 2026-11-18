using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] float openSpeed = 2f;
    [SerializeField] float openDistance = 3f;
    [SerializeField] bool opened;
    public bool locked;
    private Vector2 closedPosition;
    private Vector2 openPosition;
    private PlayerMovement player;

    public void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        openPosition = new Vector2(transform.position.x, transform.position.y + openDistance);
        closedPosition = transform.position;
        locked = true;
    }
    public void Update()
    {
        if (opened && !locked)
        {
            transform.position = Vector2.Lerp(transform.position, openPosition, openSpeed * Time.deltaTime);
        } else if (!opened || locked)
        {
            transform.position = Vector2.Lerp(transform.position, closedPosition, openSpeed * Time.deltaTime);
        }

        float playerDistance = Vector2.Distance(transform.position, player.transform.position);
        if (playerDistance <= 4f)
        {
            opened = true;
        } else if (playerDistance > 4f)
        {
            opened = false;
        }
    }
    public IEnumerator open()
    {
        opened = true;
        yield return new WaitForSeconds(4f);
        opened = false;
    }
}
