using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider2D;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnJump(InputValue value)
    {
        if (!_collider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        if (value.isPressed)
        {
            
            _rigidbody.velocity += new Vector2(0, _jumpPower);
        }
    }

    private void FlipSprite()
    {
        bool horizontalMoving = Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;
        if (horizontalMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody.velocity.x), 1);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        _rigidbody.velocity = new Vector2(moveInput.x * _runSpeed, _rigidbody.velocity.y);
        
        bool horizontalMoving = Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;
        _animator.SetBool(IsRunning, horizontalMoving);
    }
}
