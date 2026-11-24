using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] float _runSpeed = 8;
    [SerializeField] float _walkSpeed = 5;
    public float speedMulti = 1f;
    [SerializeField] float _slowedEffect = 0.7f;
    public bool slowed;
    private float _moveSpeed;
    private Vector2 _movement;

    private Rigidbody2D _rb;
    private SpriteRenderer sprt;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
        _moveSpeed = _walkSpeed;
        slowed = false;
    }

    public void UpdateSpeed()
    {
        // moves the player based on the movement Vector2
        if (slowed)
        {
            _rb.linearVelocity = _movement * _moveSpeed * _slowedEffect * speedMulti;
        }
        else if (!slowed)
        {
            _rb.linearVelocity = _movement * _moveSpeed * speedMulti;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        // updates movement vector based on WASD
        _movement = ctx.ReadValue<Vector2>();
        // Debug.Log(movement);
        UpdateSpeed();
    }
    public void Run(InputAction.CallbackContext ctx)
    {
        // Checks when shift is pressed and unpressed
        if (ctx.started)
        {
            _moveSpeed = _runSpeed;
        } else if (ctx.canceled)
        {
            _moveSpeed = _walkSpeed;
        }
        UpdateSpeed();
    }
}
