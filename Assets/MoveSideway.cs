using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSideway : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerInputAction _input;
    private Vector2 _movement;

    [SerializeField] private float movementSpeed = 500;

    void Awake()
    {
        _input = new PlayerInputAction();
        _rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        _input.Player.Movement.performed += HandlePlayerMovement;
        _input.Player.Movement.canceled += HandlePlayerMovement;
        _input.Enable();
    }

    private void HandlePlayerMovement(InputAction.CallbackContext context)
    {
         _movement = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocityX = movementSpeed * _movement.x * Time.deltaTime;
    }
}
