using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorFollowMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    void Awake()
    {
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        mousePosition = CustomUtilities.GetMousePos();
        transform.position = new Vector2(mousePosition.x + 0.25f, mousePosition.y - 0.2f);
    }
}
