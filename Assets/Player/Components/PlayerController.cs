using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    protected PlayerInputAction _input;
    protected Vector2 _movement;


    protected virtual void Awake()
    {
        _input = new PlayerInputAction();
    }

    protected virtual void Start()
    {
        _input.Player.SwingFront.performed += HandleSwingFrontLegPerformed;
        _input.Player.SwingFront.canceled += HandleSwingFrontLegCancel;
        _input.Player.SwingBack.performed += HandleSwingBackPerfromed;
        _input.Player.SwingBack.canceled += HandleSwingBackCancel;
        _input.Player.Movement.performed += HandleMovement;
        _input.Player.Movement.canceled += HandleMovement;
        _input.Enable();
    }

    private void HandleMovement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    protected virtual void HandleSwingBackCancel(InputAction.CallbackContext context)
    {
        
    }

    protected virtual void HandleSwingBackPerfromed(InputAction.CallbackContext context)
    {
        
    }

    protected virtual void HandleSwingFrontLegCancel(InputAction.CallbackContext context)
    {
        
    }

    protected virtual void HandleSwingFrontLegPerformed(InputAction.CallbackContext context)
    {
        
    }

    protected virtual void OnDisable()
    {
        _input.Disable();
        _input.Player.SwingFront.performed -= HandleSwingFrontLegPerformed;
        _input.Player.SwingFront.canceled -= HandleSwingFrontLegCancel;
        _input.Player.SwingBack.performed -= HandleSwingBackPerfromed;
        _input.Player.SwingBack.canceled -= HandleSwingBackCancel;
        _input.Player.Movement.performed -= HandleMovement;
        _input.Player.Movement.canceled -= HandleMovement;
    }
}
