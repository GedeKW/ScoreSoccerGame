using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSideway : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movement;
    [SerializeField] private float movementSpeed = 500;

    [SerializeField] private Transform leftMoveLimit;
    [SerializeField] private Transform rightMoveLimit;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetMovement(Vector2 movement)
    {
        if(movement.x > 0 && !BelowLimit(rightMoveLimit))
        {
            _movement = Vector2.zero;
            return;
        }
        if(movement.x < 0 && !BelowLimit(leftMoveLimit))
        {
            // if(movement.x > 0) Debug.Log("kanan masuk");
            _movement = Vector2.zero;
            return;
        }
        _movement = movement;

        
    }

    void FixedUpdate()
    {
        _rb.linearVelocityX = movementSpeed * _movement.x * Time.deltaTime;
    }

    public bool BelowLimit(Transform limit)
    {
        Vector2 targetPos = new Vector2(limit.position.x, transform.position.y); 
        // float dis = Vector2.Distance(transform.position,targetPos);
        //Kena floating point for 0.1f bruhhhhh....
        return Vector2.Distance(transform.position,targetPos) > 0.3f;
    }
}
