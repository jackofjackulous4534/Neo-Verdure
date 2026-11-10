using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movement;
    public float MoveSpeed;
    public float JumpPower;
    public bool isGrounded;
    public bool canMove;

    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        float movementX = ctx.ReadValue<Vector2>().x;
        float movementY = ctx.ReadValue<Vector2>().y;
    }
}
