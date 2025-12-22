using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class Player : PlayerController
{
    [Header("Kick Parameter")]
    [SerializeField] private Leg backleg;
    [SerializeField] private Leg frontLeg;

    //Movement
    [Header("Movement Parameter")]
    [SerializeField] private MoveSideway playerMove;


    


    //Kick State
    private SwingDirection _direction = SwingDirection.none;
    private bool _isSwinging;

    private Coroutine _currentCor;

    

    //Gizmos
    void OnDrawGizmos()
    {
        
    }

    //LifeCycle
    void Update()
    {
        playerMove.SetMovement(_movement);
    }

    
    //Swing leg
    protected override void HandleSwingFrontLegPerformed(InputAction.CallbackContext context)
    {
        base.HandleSwingFrontLegPerformed(context);
        if(_direction == SwingDirection.none && !_isSwinging)
        {
            StopCurrentCor();
            _currentCor = StartCoroutine(SwingUp(frontLeg,90,SwingDirection.front));
        }
    }

    protected override void HandleSwingFrontLegCancel(InputAction.CallbackContext context)
    {
        base.HandleSwingFrontLegCancel(context);
        if(_direction != SwingDirection.none && _isSwinging)
        {    
            StopCurrentCor();
            _currentCor = StartCoroutine(SwingDown(frontLeg));
        }
    }

    protected override void HandleSwingBackPerfromed(InputAction.CallbackContext context)
    {
        base.HandleSwingBackPerfromed(context);
        if(_direction == SwingDirection.none && !_isSwinging)
        {
            StopCurrentCor();
            _currentCor = StartCoroutine(SwingUp(backleg,-90,SwingDirection.back));
        }
    }

    protected override void HandleSwingBackCancel(InputAction.CallbackContext context)
    {
        base.HandleSwingBackCancel(context);
        if(_direction != SwingDirection.none && _isSwinging)
        {
            StopCurrentCor();
            _currentCor = StartCoroutine(SwingDown(backleg));  
        }
    }

    private void StopCurrentCor()
    {
        if(_currentCor != null)
        {
            StopCoroutine(_currentCor);
            _currentCor = null;
        }
    }

    IEnumerator SwingUp (Leg leg , float targetRotation, SwingDirection direction)
    {
        _isSwinging = true;
        _direction = direction;
        yield return leg.SwingLeg(targetRotation);
    }

    IEnumerator SwingDown(Leg leg)
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
