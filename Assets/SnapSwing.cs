using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnapSwing : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerInputAction _input;
    private bool _isSwinging = false;
    [SerializeField] private float legSwingSpeed = 1000f;
    IEnumerator SwingLeg(float currentRotation,float targetRotation)
    {
        while(Mathf.Abs(currentRotation - (targetRotation)) > 0.1)
        {
            currentRotation = Mathf.MoveTowards(currentRotation,targetRotation,legSwingSpeed * Time.deltaTime);
            _rb.MoveRotation(currentRotation);
            yield return null;
        }
        yield return null;
    }

    IEnumerator PlayerSwing(float targetRotation)
    {
        _isSwinging = true;
        yield return SwingLeg(_rb.rotation,targetRotation);
        yield return new WaitForSeconds(0.2f);
        yield return SwingLeg(_rb.rotation,0);
        _isSwinging = false;
        yield return null;
    }

    public IEnumerator SwingLeg(float targetRotation)
    {
        yield return SwingLeg(_rb.rotation,targetRotation);
    }

    void Update()
    {
        if ( _input.Player.SwingFront.WasPerformedThisFrame() && !_isSwinging)
        {
            StartCoroutine(PlayerSwing(90));
        }

        if ( _input.Player.SwingBack.WasPerformedThisFrame() && !_isSwinging)
        {
            StartCoroutine(PlayerSwing(-90));
        }
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new PlayerInputAction();
    }

    void Start()
    {
        _input.Enable();
    }
}
