using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // void Update()
    // {
    //     if (Keyboard.current.spaceKey.wasPressedThisFrame)
    //     {
    //         transform.position = new Vector2(0,4);
    //         rb.linearVelocity = Vector2.zero;
    //     }
    // }

    public void SetActive(bool isActive)
    {
        // rb.bodyType = !isActive? RigidbodyType2D.Dynamic: RigidbodyType2D.Kinematic;
        rb.simulated = isActive;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
        rb.linearVelocity = Vector2.zero;
    }
}
