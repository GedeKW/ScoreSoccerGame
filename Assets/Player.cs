using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private SnapSwing leftLeg;
    [SerializeField] private SnapSwing rightLeg;

    private PlayerInputAction _input;

    //Kick State
    private SwingDirection _direction;
    private bool _isSwinging;

    void Awake()
    {
        _input = new PlayerInputAction();
    }

    void Start()
    {
        _input.Player.SwingFront.performed += HandleSwingFrontLegPerformed;
        _input.Player.SwingFront.canceled += HandleSwingFrontLegCancel;
        _input.Player.SwingBack.performed += HandleSwingBackPerfromed;
        _input.Player.SwingBack.canceled += HandleSwingBackCancel;
        _input.Enable();
    }

    void OnDisable()
    {
        _input.Disable();
        _input.Player.SwingFront.performed -= HandleSwingFrontLegPerformed;
        _input.Player.SwingFront.canceled -= HandleSwingFrontLegCancel;
        _input.Player.SwingBack.performed -= HandleSwingBackPerfromed;
        _input.Player.SwingBack.canceled -= HandleSwingBackCancel;
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

    IEnumerator SwingUp (SnapSwing leg , float targetRotation, SwingDirection direction)
    {
        _isSwinging = true;
        _direction = direction;
        yield return leg.SwingLeg(targetRotation);
    }

    IEnumerator SwingDown(SnapSwing leg)
    {
        yield return leg.SwingLeg(0);
        _isSwinging = false;
        _direction = SwingDirection.none;
        yield return null;
    }

}

public enum SwingDirection
{
    none,
    front,
    back,
}
