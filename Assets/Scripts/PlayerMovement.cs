using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _footCollider;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsFalling = Animator.StringToHash("IsFalling");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    void Update()
    {
        Run();
        FlipSprite();
        Debug.Log(_rigidbody.velocity.y);
        
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y < -4)
        {
            _animator.SetBool(IsJumping, false);
            _animator.SetBool(IsFalling, true);
        }
        if(Mathf.Abs(_rigidbody.velocity.y) < 0.5f)
        {
            _animator.SetBool(IsFalling, false);
            _animator.SetBool(IsJumping, false);
        }
    }

    void OnJump(InputValue value)
    {
        if (!_footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        if (value.isPressed)
        {
            _animator.SetBool(IsJumping, true);
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
        
        bool horizontalMoving = Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon && Mathf.Abs(_rigidbody.velocity.y) > Mathf.Epsilon;
        _animator.SetBool(IsRunning, horizontalMoving);
    }
}
