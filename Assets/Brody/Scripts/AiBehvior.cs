using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class AiBehvior : MonoBehaviour
{
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
        currentState = state.ChasePathfind;
    }

    private void MoveTowards(Vector3 targetPosition, float speed)
    {
        Vector2 Direction = targetPosition - transform.position;
        Direction = Direction.normalized * speed;
        rb.linearVelocity = Direction;
    }
    private void Update()
    {
        if (currentState == state.Idle)
        {

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
            Vector3 difference = pathPoints[0] - transform.position;
            if (difference.magnitude < 0.1f)
            {
                pathPoints.RemoveAt(0);
            }
            MoveTowards(pathPoints[0], runSpeed); 
        }
    }
}
