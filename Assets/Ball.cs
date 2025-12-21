using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            transform.position = new Vector2(0,4);
            rb.linearVelocity = Vector2.zero;
        }
    }
}
