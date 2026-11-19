using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _obstacleCheckCircle;
    [SerializeField]
    private float checkDistance;
    [SerializeField]
    private LayerMask obstacleLayerMask;

    private Rigidbody2D _rigidbody;
    private PlayerAwareness _playerAwareness;
    private Vector2 _targetDirection;
    private float directionCooldown;
    private RaycastHit2D[] obstacleCollision;
    private float avoidanceCooldown;
    private Vector2 avoidanceTargetDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwareness = GetComponent<PlayerAwareness>();
        _targetDirection = transform.up;
        obstacleCollision = new RaycastHit2D[10];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTargetDirection();
        rotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
         if (_playerAwareness.AwareOfPlayer)
         {
             _targetDirection = _playerAwareness.DirectionToPlayer;
         }

        RandomDirection();
        PlayerTargetting();
        HandleObstacles();
    }

    public void RandomDirection()
    {
        directionCooldown -= Time.deltaTime;

        if (directionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            directionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandleObstacles()
    {
        avoidanceCooldown -= Time.deltaTime;

        var contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(obstacleLayerMask);
        int numberOfCollisions = Physics2D.CircleCast(
            transform.position, 
            _obstacleCheckCircle, 
            transform.up, 
            contactFilter, 
            obstacleCollision, 
            checkDistance);
        for (int index = 0; index < numberOfCollisions; index++)
        {
            var obstacleCollisions = obstacleCollision[index];

            if (obstacleCollisions.collider.gameObject == gameObject)
            {
                continue;
            }

            if (avoidanceCooldown <= 0)
            {
                avoidanceTargetDirection = obstacleCollisions.normal;
                avoidanceCooldown = 0.5f;
            }

            var targetRotation = Quaternion.LookRotation(transform.forward, avoidanceTargetDirection);
            var rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _targetDirection = rotation * Vector2.up;
            _targetDirection = obstacleCollisions.normal;
            break;
        }
    }

    private void PlayerTargetting()
    {

    }
    private void rotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        _rigidbody.linearVelocity = transform.up * _speed; 
    }

    private void OnDrawGizmos()
    {
        avoidanceCooldown -= Time.deltaTime;

        var contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(obstacleLayerMask);
        Physics2D.CircleCast(
            transform.position,
            _obstacleCheckCircle,
            transform.up,
            contactFilter,
            obstacleCollision,
            checkDistance);

    }
}
