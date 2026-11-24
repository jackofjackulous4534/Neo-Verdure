using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class AiBehvior : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] LayerMask groundLayer;
    private AStarManager AStar;
    private Rigidbody2D rb;
    public float walkSpeed;
    public float runSpeed;
    public GameObject player;
    public enum state
    {
        Idle, ChaseDirect, ChasePathfind 
    }

    private state currentState;

    private void Awake()
    {
        AStar = FindAnyObjectByType<AStarManager>();
        rb = GetComponent<Rigidbody2D>();
        currentState = state.Idle;
    }

    private void MoveTowards(Vector3 targetPosition, float speed)
    {
        Vector2 Direction = targetPosition - transform.position;
        Direction = Direction.normalized * speed;
        rb.linearVelocity = Direction;
    }
    private void Update()
    {
        CheckState();
        ExecuteState();
    }

    private void CheckState()
    {
        if (currentState == state.Idle)
        {
            if ((player.transform.position - transform.position).magnitude < sightRange)
            {
                currentState = state.ChaseDirect;
                return;
            }
        }
        else if (currentState == state.ChaseDirect)
        {
            if ((player.transform.position - transform.position).magnitude > sightRange)
            {
                currentState = state.Idle;
                return;
            }
            RaycastHit2D hitData = Physics2D.Linecast(transform.position, player.transform.position, groundLayer);
            if (hitData)
            {
                currentState = state.ChasePathfind;
            }
        }
        else if (currentState == state.ChasePathfind)
        {
            if ((player.transform.position - transform.position).magnitude > sightRange)
            {
                currentState = state.Idle;
                return;
            }
            RaycastHit2D hitData = Physics2D.Linecast(transform.position, player.transform.position, groundLayer);
            if (!hitData)
            {
                currentState = state.ChaseDirect; 
            }
        }
    }

    private void ExecuteState()
    {
        if (currentState == state.Idle)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else if (currentState == state.ChaseDirect)
        {
            MoveTowards(player.transform.position, runSpeed);
        }
        else if (currentState == state.ChasePathfind)
        {
            List<Vector3> pathPoints = AStar.GetPath(transform.position, player.transform.position);
            if (pathPoints == null)
            {
                return;
            }
            if ((pathPoints[0] - transform.position).magnitude < 1.1f)
            {
                pathPoints.RemoveAt(0);
            }
            MoveTowards(pathPoints[0], runSpeed);
        }
    }

    [SerializeField] bool _debug = true;
    private void OnDrawGizmos()
    {
        if (!_debug)
        {
            return;
        }
        Gizmos.color = Color.rebeccaPurple;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
